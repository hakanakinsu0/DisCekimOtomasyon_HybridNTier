using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.Reservations;
using Project.MvcUI.Models.PureVms.RequestModels.Reservations;
using Project.MvcUI.Models.PureVms.ResponseModels.Reservations;

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

        public ReservationController(IReservationManager reservationManager, ICustomerManager customerManager, ILocationManager locationManager, IPhotographerManager photographerManager, IServiceCategoryManager serviceCategoryManager, IPackageOptionManager packageOptionManager, IAppUserManager appUserManager)
        {
            _reservationManager = reservationManager;
            _customerManager = customerManager;
            _locationManager = locationManager;
            _photographerManager = photographerManager;
            _serviceCategoryManager = serviceCategoryManager;
            _packageOptionManager = packageOptionManager;
            _appUserManager = appUserManager;
        }



        #region ReservationIndexAction

        /// <summary>
        /// Tüm rezervasyonları listeler; isteğe bağlı olarak ID, müşteri, tarih veya durumla arama yapar.
        /// </summary>
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // 1) BLL’den tüm rezervasyonları al
            var list = await _reservationManager.GetAllAsync();

            // 2) Silinmiş kayıtları çıkar (soft-delete)
            list = list.Where(r => r.Status != DataStatus.Deleted).ToList();

            // 3) Arama terimi varsa in-memory filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                list = list.Where(r =>
                        r.Id.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        r.CustomerId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        r.ScheduledDate.ToString("g").Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        r.ReservationStatus.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                    )
                    .ToList();
            }

            // 4) PageVm’i oluştur ve view’a gönder
            var pageVm = new ReservationIndexPageVm
            {
                Request = new ReservationIndexRequestModel { SearchTerm = searchTerm },
                Response = new ReservationIndexResponseModel { Reservations = list }
            };

            return View(pageVm);
        }

        #endregion

        #region ReservationCreateAction

        /// <summary>
        /// Yeni rezervasyon formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            var pageVm = new ReservationCreatePageVm();

            // Dropdown verilerini BLL'den alıp sadece silinmemişleri seçiyoruz
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
            {
                // Dropdown’ları yeniden doldur
                return await Create();
            }

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
                await _reservationManager.CreateAsync(dto);
                TempData["SuccessMessage"] = "Rezervasyon başarıyla oluşturuldu.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                pageVm.Response.IsSuccess = false;
                pageVm.Response.ErrorMessage = ex.Message;
                // Dropdown’ları yeniden doldur
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
    }
}
