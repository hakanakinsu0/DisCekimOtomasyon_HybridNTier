using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.Common.Tools;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.Reservations;
using Project.MvcUI.Models.PureVms.RequestModels.Reservations;
using Project.MvcUI.Models.PureVms.ResponseModels.Reservations;
using System.Globalization;
using System.Text;

namespace Project.MvcUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationManager _reservationManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILocationManager _locationManager;
        private readonly IPhotographerManager _photographerManager;
        private readonly IServiceCategoryManager _serviceCategoryManager;
        private readonly IPackageOptionManager _packageOptionManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IPaymentManager _paymentManager;
        private readonly IReservationExtraManager _reservationExtraManager;
        private readonly IExtraServiceManager _extraServiceManager;


        public ReservationController(IReservationManager reservationManager, ICustomerManager customerManager, ILocationManager locationManager, IPhotographerManager photographerManager, IServiceCategoryManager serviceCategoryManager, IPackageOptionManager packageOptionManager, IAppUserManager appUserManager, IPaymentManager paymentManager, IReservationExtraManager reservationExtraManager, IExtraServiceManager extraServiceManager)
        {
            _reservationManager = reservationManager;
            _customerManager = customerManager;
            _locationManager = locationManager;
            _photographerManager = photographerManager;
            _serviceCategoryManager = serviceCategoryManager;
            _packageOptionManager = packageOptionManager;
            _appUserManager = appUserManager;
            _paymentManager = paymentManager;
            _reservationExtraManager = reservationExtraManager;
            _extraServiceManager = extraServiceManager;
        }



        #region ReservationIndexAction

        /// <summary>
        /// Tüm rezervasyonları listeler; isteğe bağlı olarak ID, müşteri, tarih veya durumla arama yapar.
        /// </summary>
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // 1) Rezervasyonları al ve filtre uygula
            var list = await _reservationManager.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                list = list
                    .Where(r =>
                        r.Id.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                     || r.CustomerId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                     || r.ScheduledDate.ToString("g").Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                     || r.ReservationStatus.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // 2) PageVm oluştur
            var vm = new ReservationIndexPageVm
            {
                Request = new ReservationIndexRequestModel { SearchTerm = searchTerm },
                Response = new ReservationIndexResponseModel { Reservations = list }
            };

            // 3) Müşteri isimlerini doldur
            var customerIds = list.Select(r => r.CustomerId).Distinct();
            foreach (var cid in customerIds)
            {
                var c = await _customerManager.GetByIdAsync(cid);
                vm.CustomerNames[cid] = c != null
                    ? $"{c.BrideName} {c.GroomName} {c.LastName}"
                    : "—";
            }

            // 4) Mekan isimlerini doldur
            var locationIds = list.Select(r => r.LocationId).Distinct();
            foreach (var lid in locationIds)
            {
                var loc = await _locationManager.GetByIdAsync(lid);
                vm.LocationNames[lid] = loc != null
                    ? loc.Name
                    : "—";
            }

            // 5) Fotoğrafçı isimlerini doldur
            var photographerIds = list.Select(r => r.PhotographerId).Distinct();
            foreach (var pid in photographerIds)
            {
                var p = await _photographerManager.GetByIdAsync(pid);
                vm.PhotographerNames[pid] = p != null
                    ? $"{p.FirstName} {p.LastName}"
                    : "—";
            }

            return View(vm);
        }

        #endregion

        #region ReservationCreateAction

        /// <summary>
        /// Yeni rezervasyon formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            var pageVm = new ReservationCreatePageVm();

            // 1. Dropdown verileri
            pageVm.Customers = (await _customerManager.GetAllAsync())
                .Where(c => c.Status != DataStatus.Deleted)
                .Select(c => new SelectListItem($"{c.BrideName} {c.GroomName} {c.LastName}", c.Id.ToString()))
                .ToList();

            pageVm.Locations = (await _locationManager.GetAllAsync())
                .Where(l => l.Status != DataStatus.Deleted)
                .Select(l => new SelectListItem(l.Name, l.Id.ToString()))
                .ToList();

            pageVm.Photographers = (await _photographerManager.GetAllAsync())
                .Where(p => p.Status != DataStatus.Deleted)
                .Select(p => new SelectListItem($"{p.FirstName} {p.LastName}", p.Id.ToString()))
                .ToList();

            pageVm.ServiceCategories = (await _serviceCategoryManager.GetAllAsync())
                .Where(sc => sc.Status != DataStatus.Deleted)
                .Select(sc => new SelectListItem(sc.Name, sc.Id.ToString()))
                .ToList();

            pageVm.PackageOptions = (await _packageOptionManager.GetAllAsync())
                .Where(po => po.Status != DataStatus.Deleted)
                .Select(po => new SelectListItem(po.Name, po.Id.ToString()))
                .ToList();

            pageVm.AppUsers = (await _appUserManager.GetAllAsync())
                .Where(u => u.Status != DataStatus.Deleted)
                .Select(u => new SelectListItem(u.UserName, u.Id.ToString()))
                .ToList();

            // 2. RequestModel’e sadece "opsiyonel" dropdown’lar için default atama yapıyoruz
            pageVm.Request = new ReservationCreateRequestModel
            {
                // ScheduledDate bugün saat 13:00 olacak
                ScheduledDate = DateTime.Today.AddHours(13),
                LocationId = pageVm.Locations.Any() ? int.Parse(pageVm.Locations.First().Value) : default,
                PhotographerId = pageVm.Photographers.Any() ? int.Parse(pageVm.Photographers.First().Value) : default,
                ServiceCategoryId = pageVm.ServiceCategories.Any() ? int.Parse(pageVm.ServiceCategories.First().Value) : default,
                PackageOptionId = pageVm.PackageOptions.Any() ? int.Parse(pageVm.PackageOptions.First().Value) : default,
                AppUserId = pageVm.AppUsers.Any() ? int.Parse(pageVm.AppUsers.First().Value) : default,
                Duration = TimeSpan.FromHours(1.5),
                ReservationStatus = Enum.GetValues(typeof(ReservationStatus))
                                       .Cast<ReservationStatus>()
                                       .First()
            };

            return View(pageVm);
        }

        /// <summary>
        /// Formdan gelen verilerle yeni rezervasyonu oluşturur.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationCreatePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return await Create();

            var dto = new ReservationDto
            {
                CustomerId = pageVm.Request.CustomerId,
                LocationId = pageVm.Request.LocationId,
                PhotographerId = pageVm.Request.PhotographerId,
                ServiceCategoryId = pageVm.Request.ServiceCategoryId,
                PackageOptionId = pageVm.Request.PackageOptionId,
                AppUserId = pageVm.Request.AppUserId,
                ScheduledDate = pageVm.Request.ScheduledDate,
                Duration = pageVm.Request.Duration,
                ReservationStatus = pageVm.Request.ReservationStatus,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            try
            {
                // DTO’nun Id’si dönüyor
                var created = await _reservationManager.CreateAsync(dto);
                TempData["SuccessMessage"] = "Rezervasyon başarıyla oluşturuldu.";

                //  → BURASI EKLENDİ: Ekstra hizmet sayfasına yönlendir
                return RedirectToAction(
                    actionName: "Create",
                    controllerName: "ReservationExtra",
                    routeValues: new
                    {
                        reservationId = created.Id,
                        packageOptionId = created.PackageOptionId
                    });
            }
            catch (Exception ex)
            {
                pageVm.Response.IsSuccess = false;
                pageVm.Response.ErrorMessage = ex.Message;
                await Create();
                return View(pageVm);
            }
        }

        #endregion

        #region ReservationEditAction

        /// <summary>
        /// Rezervasyon düzenleme formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _reservationManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            // Dropdown verileri
            var customers = (await _customerManager.GetAllAsync()).Where(c => c.Status != DataStatus.Deleted);
            var locations = (await _locationManager.GetAllAsync()).Where(l => l.Status != DataStatus.Deleted);
            var photographers = (await _photographerManager.GetAllAsync()).Where(p => p.Status != DataStatus.Deleted);
            var categories = (await _serviceCategoryManager.GetAllAsync()).Where(sc => sc.Status != DataStatus.Deleted);
            var packages = (await _packageOptionManager.GetAllAsync()).Where(po => po.Status != DataStatus.Deleted);
            var appUsers = (await _appUserManager.GetAllAsync()).Where(u => u.Status != DataStatus.Deleted);

            var pageVm = new ReservationEditPageVm
            {
                Request = new ReservationEditRequestModel
                {
                    Id = dto.Id,
                    CustomerId = dto.CustomerId,
                    LocationId = dto.LocationId,
                    PhotographerId = dto.PhotographerId,
                    ServiceCategoryId = dto.ServiceCategoryId,
                    PackageOptionId = dto.PackageOptionId,
                    AppUserId = dto.AppUserId,
                    ScheduledDate = dto.ScheduledDate,
                    Duration = dto.Duration,
                    ReservationStatus = dto.ReservationStatus
                },
                Customers = customers.Select(c => new SelectListItem($"{c.BrideName} {c.GroomName} {c.LastName}", c.Id.ToString())).ToList(),
                Locations = locations.Select(l => new SelectListItem(l.Name, l.Id.ToString())).ToList(),
                Photographers = photographers.Select(p => new SelectListItem($"{p.FirstName} {p.LastName}", p.Id.ToString())).ToList(),
                ServiceCategories = categories.Select(sc => new SelectListItem(sc.Name, sc.Id.ToString())).ToList(),
                PackageOptions = packages.Select(po => new SelectListItem(po.Name, po.Id.ToString())).ToList(),
                AppUsers = appUsers.Select(u => new SelectListItem(u.UserName, u.Id.ToString())).ToList()
            };

            return View(pageVm);
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle rezervasyonu günceller.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationEditPageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                // dropdownları yeniden yükle
                return await Edit(pageVm.Request.Id);
            }

            var existing = await _reservationManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null)
                return NotFound();

            var dto = new ReservationDto
            {
                Id = pageVm.Request.Id,
                CustomerId = pageVm.Request.CustomerId,
                LocationId = pageVm.Request.LocationId,
                PhotographerId = pageVm.Request.PhotographerId,
                ServiceCategoryId = pageVm.Request.ServiceCategoryId,
                PackageOptionId = pageVm.Request.PackageOptionId,
                AppUserId = pageVm.Request.AppUserId,
                ScheduledDate = pageVm.Request.ScheduledDate,
                Duration = pageVm.Request.Duration,
                ReservationStatus = pageVm.Request.ReservationStatus,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _reservationManager.UpdateAsync(dto);
                TempData["SuccessMessage"] = "Rezervasyon başarıyla güncellendi.";
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

        #region ReservationDeleteAction

        /// <summary>
        /// Rezervasyon silme onay ekranını görüntüler.
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _reservationManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new ReservationDeletePageVm
            {
                Request = new ReservationDeleteRequestModel
                {
                    Id = dto.Id,
                    Description = $"Rezervasyon #{dto.Id} - {dto.ScheduledDate:g}"
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Rezervasyonu soft-delete ile silinmiş olarak işaretler.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ReservationDeletePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = await _reservationManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            await _reservationManager.MakePassiveAsync(new ReservationDto { Id = dto.Id });

            TempData["SuccessMessage"] = "Rezervasyon başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendSummaryEmail(int id)
        {
            // 1) Rezervasyonu al
            var reservation = await _reservationManager.GetByIdAsync(id);
            if (reservation == null || reservation.Status == DataStatus.Deleted)
                return NotFound();

            // 2) Müşteriyi al
            var customer = await _customerManager.GetByIdAsync(reservation.CustomerId);
            if (customer == null || string.IsNullOrWhiteSpace(customer.Email))
            {
                TempData["ErrorMessage"] = "Müşterinin geçerli bir e-posta adresi yok.";
                return RedirectToAction(nameof(Summary), new { id });
            }

            // 3) Mekan, kategori ve paket adlarını al
            var location = await _locationManager.GetByIdAsync(reservation.LocationId);
            var category = await _serviceCategoryManager.GetByIdAsync(reservation.ServiceCategoryId);
            var package = await _packageOptionManager.GetByIdAsync(reservation.PackageOptionId);

            string locationName = location?.Name ?? "—";
            string categoryName = category?.Name ?? "—";
            string packageName = package?.Name ?? "—";

            // 4) Rezervasyona eklenmiş ekstra hizmetleri al ve adlarını topla
            var reExtras = await _reservationExtraManager.GetAllAsync();
            var myExtras = reExtras
                .Where(x => x.ReservationId == id && x.Status != DataStatus.Deleted)
                .ToList();

            var extraNames = new List<string>();
            foreach (var re in myExtras)
            {
                var svc = await _extraServiceManager.GetByIdAsync(re.ExtraServiceId);
                if (svc != null)
                    extraNames.Add(svc.Name);
            }

            // 5) Ödemeleri al
            var payments = await _paymentManager.GetByReservationIdAsync(id);

            // 6) Yardımcı fonksiyonlar
            var tr = new CultureInfo("tr-TR");
            string fmtDate(DateTime dt) => dt.ToString("dd'/'MM'/'yyyy dddd HH:mm", tr);
            string fmtStatus(ReservationStatus s) => s switch
            {
                ReservationStatus.Created => "Rezervasyon Oluşturuldu",
                ReservationStatus.PhotographerAssigned => "Fotoğrafçı Atandı",
                ReservationStatus.ShootCompleted => "Çekim Yapıldı",
                ReservationStatus.SentToPrint => "Baskıya Gönderildi",
                ReservationStatus.AlbumReceived => "Albüm Teslim Alındı",
                ReservationStatus.DeliveredToCustomer => "Müşteriye Teslim Edildi",
                _ => s.ToString()
            };

            // 7) Mail konusunu ve gövdesini hazırla
            var subject = $"Dış Çekim Rezervasyon #{3000 + reservation.Id} – {customer.BrideName} {customer.GroomName} {customer.LastName}";
            var sb = new StringBuilder();
            sb.AppendLine("<html><body style=\"font-family:Arial,sans-serif;\">");
            sb.AppendLine($"<h2>Rezervasyon Özeti</h2>");
            sb.AppendLine($"<p>Merhaba {customer.BrideName} Hanım ve {customer.GroomName} Bey,</p>");
            sb.AppendLine("<h3>Rezervasyon Bilgileri</h3>");
            sb.AppendLine("<ul>");
            sb.AppendLine($"  <li><strong>Rezervasyon No:</strong> {3000 + reservation.Id}</li>");
            sb.AppendLine($"  <li><strong>Mekan:</strong> {locationName}</li>");
            sb.AppendLine($"  <li><strong>Hizmet Kategorisi:</strong> {categoryName}</li>");
            sb.AppendLine($"  <li><strong>Paket Seçeneği:</strong> {packageName}</li>");

            if (extraNames.Any())
            {
                sb.AppendLine("  <li><strong>Ekstra Hizmetler:</strong></li>");
                sb.AppendLine("  <ul>");
                foreach (var name in extraNames)
                {
                    sb.AppendLine($"    <li> {name}</li>");
                }
                sb.AppendLine("  </ul>");
            }
            else
            {
                sb.AppendLine("  <li><strong>Ekstra Hizmet:</strong> Yok</li>");
            }

            sb.AppendLine($"  <li><strong>Tarih:</strong> {fmtDate(reservation.ScheduledDate)}</li>");
            sb.AppendLine($"  <li><strong>Süre:</strong> {reservation.Duration}</li>");
            sb.AppendLine($"  <li><strong>Durum:</strong> {fmtStatus(reservation.ReservationStatus)}</li>");
            sb.AppendLine("</ul>");

            sb.AppendLine("<h3>Ödeme Bilgileri</h3>");
            sb.AppendLine("<table border=\"1\" cellpadding=\"5\" cellspacing=\"0\" style=\"border-collapse:collapse;\">");
            sb.AppendLine("  <thead style=\"background:#f2f2f2;\">");
            sb.AppendLine("    <tr>");
            sb.AppendLine("      <th>Ödeme Tarihi</th>");
            sb.AppendLine("      <th>Toplam</th>");
            sb.AppendLine("      <th>Ödenen</th>");
            sb.AppendLine("      <th>Kalan</th>");
            sb.AppendLine("    </tr>");
            sb.AppendLine("  </thead>");
            sb.AppendLine("  <tbody>");
            foreach (var p in payments)
            {
                var date = p.LastPaymentDate.HasValue
                    ? fmtDate(p.LastPaymentDate.Value)
                    : "-";
                sb.AppendLine("    <tr>");
                sb.AppendLine($"      <td>{date}</td>");
                sb.AppendLine($"      <td>{p.TotalAmount:N2}₺</td>");
                sb.AppendLine($"      <td>{p.PaidAmount:N2}₺</td>");
                sb.AppendLine($"      <td>{p.RemainingAmount:N2}₺</td>");
                sb.AppendLine("    </tr>");
            }
            sb.AppendLine("  </tbody>");
            sb.AppendLine("</table>");
            sb.AppendLine("<p>Teşekkür ederiz, iyi günler dileriz.</p>");
            sb.AppendLine("</body></html>");

            // 8) Mail'i gönder
            try
            {
                await MailService.SendAsync(
                    receiver: customer.Email,
                    body: sb.ToString(),
                    subject: subject
                );
                TempData["SuccessMessage"] = "Özet e-postası başarıyla gönderildi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "E-posta gönderilemedi: " + ex.Message;
            }

            return RedirectToAction(nameof(Summary), new { id });
        }



        /// <summary>
        /// Rezervasyon ve ödeme bilgilerini özet olarak gösterir.
        /// </summary>
        public async Task<IActionResult> Summary(int id)
        {
            // 1) Rezervasyonu getir
            var reservation = await _reservationManager.GetByIdAsync(id);
            if (reservation == null || reservation.Status == DataStatus.Deleted)
                return NotFound();

            // 2) İlişkili veriler
            var customer = await _customerManager.GetByIdAsync(reservation.CustomerId);
            var location = await _locationManager.GetByIdAsync(reservation.LocationId);
            var category = await _serviceCategoryManager.GetByIdAsync(reservation.ServiceCategoryId);
            var packageOpt = await _packageOptionManager.GetByIdAsync(reservation.PackageOptionId);

            // 3) Ekstra hizmetleri çek, toplam fiyatını hesapla
            var extras = (await _reservationExtraManager.GetAllAsync())
                         .Where(x => x.ReservationId == id && x.Status != DataStatus.Deleted);

            decimal extrasTotal = 0m;
            foreach (var ex in extras)
            {
                var svc = await _extraServiceManager.GetByIdAsync(ex.ExtraServiceId);
                extrasTotal += svc.Price * ex.Quantity;
            }

            // 4) Ödemeleri çek
            var payments = await _paymentManager.GetByReservationIdAsync(id);

            // 5) VM’i doldur
            var vm = new ReservationSummaryPageVm
            {
                Reservation = reservation,
                Payments = payments,
                CustomerName = $"{customer.BrideName} {customer.GroomName} {customer.LastName}",
                LocationName = location?.Name ?? "—",
                ServiceCategoryName = category?.Name ?? "—",
                PackageOptionName = packageOpt?.Name ?? "—",

                BaseAmount = packageOpt?.Price ?? 0m,
                ExtrasTotal = extrasTotal
            };

            return View(vm);
        }

    }
}
