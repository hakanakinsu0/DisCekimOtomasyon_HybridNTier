using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.Payments;
using Project.MvcUI.Models.PureVms.RequestModels.Payments;
using Project.MvcUI.Models.PureVms.ResponseModels.Payments;

namespace Project.MvcUI.Controllers
{
    public class PaymentController : Controller
    {
        readonly IPaymentManager _paymentManager;
        readonly IReservationManager _reservationManager;
        readonly ICustomerManager _customerManager;
        readonly IPackageOptionManager _packageOptionManager;
        readonly IReservationExtraManager _reservationExtraManager;
        readonly IExtraServiceManager _serviceManager;

        public PaymentController(IPaymentManager paymentManager, IReservationManager reservationManager, ICustomerManager customerManager, IPackageOptionManager packageOptionManager, IReservationExtraManager reservationExtraManager, IExtraServiceManager serviceManager)
        {
            _paymentManager = paymentManager;
            _reservationManager = reservationManager;
            _customerManager = customerManager;
            _packageOptionManager = packageOptionManager;
            _reservationExtraManager = reservationExtraManager;
            _serviceManager = serviceManager;
        }

        #region PaymentIndexAction

        /// <summary>
        /// Tüm ödemeleri listeler; isteğe bağlı olarak rezervasyon numarası, tutar veya tarih ile arama yapar.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // 1) BLL'den tüm ödemeleri al
            var list = await _paymentManager.GetAllAsync(); // BaseManager üzerinden geliyor :contentReference[oaicite:4]{index=4}:contentReference[oaicite:5]{index=5}

            // 2) Arama terimi varsa in-memory filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                list = list
                    .Where(p =>
                        p.ReservationId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                        || p.TotalAmount.ToString("N2").Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                        || p.PaidAmount.ToString("N2").Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                        || p.RemainingAmount.ToString("N2").Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                        || (p.LastPaymentDate.HasValue
                            && p.LastPaymentDate.Value.ToString("g")
                                .Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    )
                    .ToList();
            }

            // 3) PageVm oluştur ve view'a gönder
            var pageVm = new PaymentIndexPageVm
            {
                Request = new PaymentIndexRequestModel { SearchTerm = searchTerm },
                Response = new PaymentIndexResponseModel { Payments = list }
            };

            // Her farklı reservationId için:
            var distinctIds = list.Select(p => p.ReservationId).Distinct();
            foreach (var resId in distinctIds)
            {
                // 1) Rezervasyonu getir
                var reservation = await _reservationManager.GetByIdAsync(resId);
                if (reservation == null)
                {
                    pageVm.CustomerNames[resId] = "—";
                    continue;
                }

                // 2) Oradan CustomerId'yi alıp müşteri kaydını getir
                var customer = await _customerManager.GetByIdAsync(reservation.CustomerId);
                if (customer == null)
                {
                    pageVm.CustomerNames[resId] = "—";
                }
                else
                {
                    pageVm.CustomerNames[resId] =
                        $"{customer.BrideName} {customer.GroomName} {customer.LastName}";
                }
            }

            return View(pageVm);
        }

        #endregion

        #region PaymentCreateAction

        /// <summary>
        /// Ödeme ekleme formunu görüntüler; rezervasyon dropdown’unu doldurur ve
        /// toplam tutarı paket+ekstra hesaplayıp formda gösterir (düzenlenebilir).
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create(int reservationId, decimal totalAmount = 0m)
        {
            // 1) Rezervasyonu getir
            var reservation = await _reservationManager.GetByIdAsync(reservationId);
            if (reservation == null || reservation.Status == DataStatus.Deleted)
                return NotFound();

            // 2) Müşteriyi getir
            var customer = await _customerManager.GetByIdAsync(reservation.CustomerId);
            var customerName = $"{customer.BrideName} {customer.GroomName} {customer.LastName}";

            // 3) Önceki ödemeleri al, bakiyeyi hesapla
            var payments = await _paymentManager.GetByReservationIdAsync(reservationId);
            var paidSoFar = payments.Sum(p => p.PaidAmount);

            // 4) Eğer URL’den totalAmount geldiyse (ReservationExtra’dan) onu al,
            //    aksi halde paket+ekstra toplamı hesapla.
            decimal computedTotal;
            if (totalAmount > 0m)
            {
                computedTotal = totalAmount;
            }
            else
            {
                var pkg = await _packageOptionManager.GetByIdAsync(reservation.PackageOptionId);
                var baseAmount = pkg.Price;

                var extras = (await _reservationExtraManager.GetAllAsync())
                    .Where(x => x.ReservationId == reservationId && x.Status != DataStatus.Deleted)
                    .ToList();
                var allServices = await _serviceManager.GetAllAsync();
                var extrasTotal = extras.Sum(e =>
                {
                    var svc = allServices.FirstOrDefault(s => s.Id == e.ExtraServiceId);
                    return svc != null
                        ? svc.Price * e.Quantity
                        : 0m;
                });

                computedTotal = baseAmount + extrasTotal;
            }

            // 5) VM’i doldur
            var pageVm = new PaymentCreatePageVm
            {
                Request = new PaymentCreateRequestModel
                {
                    ReservationId = reservationId,
                    TotalAmount = computedTotal,
                    PaidAmount = 0m
                },
                TotalAmount = computedTotal,
                RemainingAmount = computedTotal - paidSoFar,
                CustomerName = customerName,
                Reservations = new List<SelectListItem>
        {
            new SelectListItem(
                text:     $"#{reservation.Id} – {reservation.ScheduledDate:dd'/'MM'/'yyyy HH:mm}",
                value:    reservation.Id.ToString(),
                selected: true)
        }
            };

            return View(pageVm);
        }

        /// <summary>
        /// Yeni ödeme işlemini gerçekleştirir; girilen totalAmount’a göre kalan hesaplanır.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreatePageVm pageVm)
        {
            // 1) Form validasyonu
            if (!ModelState.IsValid)
                return await Create(pageVm.Request.ReservationId);

            // 2) Mevcut ödemeleri alıp geçmiş ödeneni hesapla
            var payments = await _paymentManager.GetByReservationIdAsync(pageVm.Request.ReservationId);
            var paidSoFar = payments.Sum(p => p.PaidAmount);

            // 3) Toplam tutarı belirle
            var totalAmount = payments.Any()
                ? payments.First().TotalAmount   // önceki kayıttan gelen toplam
                : pageVm.Request.TotalAmount.Value; // formdan gelen ilk ödeme tutarı

            // 4) Kalan bakiyeyi hesapla
            var remainingBefore = totalAmount - paidSoFar;

            // — Eğer bakiye sıfır veya negatifse, yeni ödeme girişine izin verme —
            if (remainingBefore <= 0)
            {
                TempData["ErrorMessage"] = "Bu rezervasyon için borç bulunmamaktadır.";
                return RedirectToAction("Summary", "Reservation", new { id = pageVm.Request.ReservationId });
            }

            // 5) Yeni ödenecek tutarı ve kalan sonrası bakiyeyi hesapla
            var newPaid = pageVm.Request.PaidAmount;
            var remainingAfter = remainingBefore - newPaid;

            // 6) DTO oluşturup kaydet
            var dto = new PaymentDto
            {
                ReservationId = pageVm.Request.ReservationId,
                TotalAmount = totalAmount,
                PaidAmount = newPaid,
                RemainingAmount = remainingAfter,
                LastPaymentDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _paymentManager.CreateAsync(dto);
            TempData["SuccessMessage"] = "Ödeme başarıyla kaydedildi.";

            // 7) Özet sayfasına yönlendir
            return RedirectToAction("Summary", "Reservation", new { id = dto.ReservationId });
        }

        #endregion


        #region PaymentEditAction

        /// <summary>
        /// Mevcut ödemenin düzenleme formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            // DTO’yu al
            var existing = await _paymentManager.GetByIdAsync(id);
            if (existing == null || existing.Status == DataStatus.Deleted)
                return NotFound();

            // Rezervasyon dropdown’u için aktif rezervasyonları çek
            var reservations = (await _reservationManager.GetAllAsync())
                                   .Where(r => r.Status != DataStatus.Deleted)
                                   .Select(r => new SelectListItem(
                                       text: $"#{r.Id} – {r.ScheduledDate:g}",
                                       value: r.Id.ToString()))
                                   .ToList();

            // PageVm hazırla
            var pageVm = new PaymentEditPageVm
            {
                Request = new PaymentEditRequestModel
                {
                    Id = existing.Id,
                    ReservationId = existing.ReservationId,
                    TotalAmount = existing.TotalAmount,
                    PaidAmount = existing.PaidAmount
                },
                Reservations = reservations
            };

            return View(pageVm);
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle ödemeyi günceller.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PaymentEditPageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                // Dropdown’u yeniden yükle
                return await Edit(pageVm.Request.Id);
            }

            // Mevcut kaydı al
            var existing = await _paymentManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null || existing.Status == DataStatus.Deleted)
                return NotFound();

            // DTO’ya dönüştür, CreatedDate’i koru, ModifiedDate’i güncelle
            var dto = new PaymentDto
            {
                Id = existing.Id,
                ReservationId = pageVm.Request.ReservationId,
                TotalAmount = pageVm.Request.TotalAmount,
                PaidAmount = pageVm.Request.PaidAmount,
                RemainingAmount = pageVm.Request.TotalAmount - pageVm.Request.PaidAmount, // kalan tutar
                LastPaymentDate = DateTime.Now,        // son ödeme tarihi
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _paymentManager.UpdateAsync(dto);  // güncelleme
                TempData["SuccessMessage"] = "Ödeme başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                pageVm.Response.IsSuccess = false;
                pageVm.Response.ErrorMessage = ex.Message;
                return View(pageVm);
            }
        }

        #endregion

        #region PaymentDeleteAction

        /// <summary>
        /// Ödeme silme onay ekranını görüntüler.
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _paymentManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new PaymentDeletePageVm
            {
                Request = new PaymentDeleteRequestModel
                {
                    Id = dto.Id,
                    Description = $"Ödeme #{dto.Id}: {dto.PaidAmount:N2}₺ / {dto.TotalAmount:N2}₺"
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Ödemeyi soft-delete ile silinmiş olarak işaretler.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PaymentDeletePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = await _paymentManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            await _paymentManager.MakePassiveAsync(new PaymentDto { Id = dto.Id });

            TempData["SuccessMessage"] = "Ödeme başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
