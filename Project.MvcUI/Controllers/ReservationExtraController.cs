using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.ReservationExtras;
using Project.MvcUI.Models.PureVms.RequestModels.ReservationExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.ReservationExtras;

namespace Project.MvcUI.Controllers
{
    [Authorize]
    public class ReservationExtraController : Controller
    {
        readonly IReservationManager _reservationManager;
        readonly IExtraServiceManager _serviceManager;
        readonly IReservationExtraManager _reservationExtraManager;

        public ReservationExtraController(IReservationManager reservationMgr, IExtraServiceManager serviceMgr, IReservationExtraManager reservationExtraMgr)
        {
            _reservationManager = reservationMgr;
            _serviceManager = serviceMgr;
            _reservationExtraManager = reservationExtraMgr;
        }

        #region ReservationExtraIndexAction

        /// <summary>
        /// Rezervasyona ait ekstra hizmetleri listeler; isteğe bağlı servis adı veya miktar ile arama yapar.
        /// </summary>
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // 1) BLL’den tüm kayıtları al
            var allItems = await _reservationExtraManager.GetAllAsync(); // BaseManager’den :contentReference[oaicite:0]{index=0}:contentReference[oaicite:1]{index=1}

            // 2) Silinmişleri çıkar
            var filtered = allItems
                .Where(x => x.Status != DataStatus.Deleted)
                .ToList();

            // 3) Arama terimi varsa in-memory filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                filtered = filtered
                    .Where(x =>
                        x.ReservationId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                        || x.ExtraServiceId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                        || x.Quantity.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                    )
                    .ToList();
            }

            // 4) PageVm’i oluştur
            var pageVm = new ReservationExtraIndexPageVm
            {
                Request = new ReservationExtraIndexRequestModel { SearchTerm = searchTerm },
                Response = new ReservationExtraIndexResponseModel { Items = filtered }
            };

            return View(pageVm);
        }

        #endregion

        #region ReservationExtraCreateAction

        /// <summary>
        /// Ekstra hizmet ekleme formunu görüntüler; dropdown’ları doldurur.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            // Aktif rezervasyonlar
            var resList = (await _reservationManager.GetAllAsync())
                              .Where(r => r.Status != DataStatus.Deleted)
                              .ToList();

            // Aktif ekstra hizmetler
            var svcList = (await _serviceManager.GetAllAsync())
                              .Where(s => s.Status != DataStatus.Deleted)
                              .ToList();

            var pageVm = new ReservationExtraCreatePageVm
            {
                Reservations = resList
                    .Select(r => new SelectListItem($"#{r.Id} – {r.ScheduledDate:g}", r.Id.ToString()))
                    .ToList(),
                ExtraServices = svcList
                    .Select(s => new SelectListItem(s.Name, s.Id.ToString()))
                    .ToList()
            };

            return View(pageVm);
        }

        /// <summary>
        /// Yeni ekstra hizmet kaydını ekler, geçersizse formu tekrar gösterir.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationExtraCreatePageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                // Dropdown’ları yeniden yükle
                return await Create();
            }

            // DTO’ya dönüştür
            var dto = new ReservationExtraDto
            {
                ReservationId = pageVm.Request.ReservationId,
                ExtraServiceId = pageVm.Request.ExtraServiceId,
                Quantity = pageVm.Request.Quantity,
                CreatedDate = System.DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _reservationExtraManager.CreateAsync(dto);

            TempData["SuccessMessage"] = "Ekstra hizmet başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region ReservationExtraEditAction

        /// <summary>
        /// Mevcut rezervasyona ait ekstra hizmet düzenleme formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _reservationExtraManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            // Dropdown verilerini hazırla
            var resList = (await _reservationManager.GetAllAsync())
                              .Where(r => r.Status != DataStatus.Deleted)
                              .ToList();
            var svcList = (await _serviceManager.GetAllAsync())
                              .Where(s => s.Status != DataStatus.Deleted)
                              .ToList();

            var pageVm = new ReservationExtraEditPageVm
            {
                Request = new ReservationExtraEditRequestModel
                {
                    Id = dto.Id,
                    ReservationId = dto.ReservationId,
                    ExtraServiceId = dto.ExtraServiceId,
                    Quantity = dto.Quantity
                },
                Reservations = resList
                    .Select(r => new SelectListItem(
                        $"#{r.Id} – {r.ScheduledDate:g}",
                        r.Id.ToString()))
                    .ToList(),
                ExtraServices = svcList
                    .Select(s => new SelectListItem(s.Name, s.Id.ToString()))
                    .ToList()
            };

            return View(pageVm);
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle ekstra hizmet kaydını günceller.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationExtraEditPageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                // Dropdown’ları yeniden yükle
                return await Edit(pageVm.Request.Id);
            }

            var existing = await _reservationExtraManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null || existing.Status == DataStatus.Deleted)
                return NotFound();

            var dto = new ReservationExtraDto
            {
                Id = existing.Id,
                ReservationId = pageVm.Request.ReservationId,
                ExtraServiceId = pageVm.Request.ExtraServiceId,
                Quantity = pageVm.Request.Quantity,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = System.DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _reservationExtraManager.UpdateAsync(dto);
                TempData["SuccessMessage"] = "Ekstra hizmet başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                pageVm.Response.IsSuccess = false;
                pageVm.Response.ErrorMessage = ex.Message;
                return View(pageVm);
            }
        }

        #endregion

        #region ReservationExtraDeleteAction

        /// <summary>
        /// Rezervasyona ait ekstra hizmet silme onay ekranını görüntüler.
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _reservationExtraManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new ReservationExtraDeletePageVm
            {
                Request = new ReservationExtraDeleteRequestModel
                {
                    Id = dto.Id,
                    Description = $"Rez #{dto.ReservationId}, Servis #{dto.ExtraServiceId}, Miktar: {dto.Quantity}"
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Rezervasyona ait ekstra hizmet kaydını soft-delete ile silinmiş olarak işaretler.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ReservationExtraDeletePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = await _reservationExtraManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            await _reservationExtraManager.MakePassiveAsync(new ReservationExtraDto { Id = dto.Id });

            TempData["SuccessMessage"] = "Ekstra hizmet kaydı başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
