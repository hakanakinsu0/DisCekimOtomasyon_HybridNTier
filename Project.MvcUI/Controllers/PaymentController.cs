using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
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

        public PaymentController(IPaymentManager paymentManager, IReservationManager reservationManager)
        {
            _paymentManager = paymentManager;
            _reservationManager = reservationManager;
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

            return View(pageVm);
        }

        #endregion

        #region PaymentCreateAction

        /// <summary>
        /// Ödeme ekleme formunu görüntüler; rezervasyon dropdown’unu doldurur.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            // Tüm rezervasyonları çek ve soft-deleted olanları çıkar
            var reservations = (await _reservationManager.GetAllAsync())
                                   .Where(r => r.Status != DataStatus.Deleted)
                                   .ToList();

            var pageVm = new PaymentCreatePageVm
            {
                Reservations = reservations
                    .Select(r => new SelectListItem(
                        text: $"#{r.Id} – {r.ScheduledDate:g}",
                        value: r.Id.ToString()))
                    .ToList()
            };

            return View(pageVm);
        }

        /// <summary>
        /// Yeni ödeme işlemini gerçekleştirir; RemainingAmount ve LastPaymentDate otomatik hesaplanır.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreatePageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                // Dropdown’u yeniden yükle
                return await Create();
            }

            // DTO’ya dönüştür
            var dto = new PaymentDto
            {
                ReservationId = pageVm.Request.ReservationId,
                TotalAmount = pageVm.Request.TotalAmount,      // Kullanıcı girdi
                PaidAmount = pageVm.Request.PaidAmount,       // Kullanıcı girdi
                RemainingAmount = pageVm.Request.TotalAmount    // Geçici, aşağıda düzeltiyoruz
                                  - pageVm.Request.PaidAmount,
                LastPaymentDate = DateTime.Now,                    // Son ödeme tarihi şimdi
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _paymentManager.CreateAsync(dto);              // BaseManager.CreateAsync() :contentReference[oaicite:0]{index=0}:contentReference[oaicite:1]{index=1}

            TempData["SuccessMessage"] = "Ödeme başarıyla kaydedildi.";
            return RedirectToAction(nameof(Index));
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
