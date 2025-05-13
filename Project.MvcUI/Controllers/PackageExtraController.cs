using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.PackageExtras;
using Project.MvcUI.Models.PureVms.RequestModels.PackageExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.PackageExtras;

namespace Project.MvcUI.Controllers
{
    public class PackageExtraController : Controller
    {
        readonly IPackageExtraManager _packageExtraManager;
        readonly IPackageOptionManager _packageOptionManager;
        readonly IExtraServiceManager _extraServiceManager;

        public PackageExtraController(IPackageExtraManager packageExtraManager, IPackageOptionManager packageOptionManager, IExtraServiceManager extraServiceManager)
        {
            _packageExtraManager = packageExtraManager;
            _packageOptionManager = packageOptionManager;
            _extraServiceManager = extraServiceManager;
        }

        #region PackageExtraIndexAction

        /// <summary>
        /// Paket ekstra listesini getirir; isteğe bağlı arama terimine göre Quantity, PackageOptionId veya ExtraServiceId üzerinden filtre uygular.
        /// </summary>
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // 1) Tüm kayıtları al
            var list = await _packageExtraManager.GetAllAsync();

            // 2) Arama varsa in-memory filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                list = list
                    .Where(d =>
                        d.PackageOptionId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                     || d.ExtraServiceId.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                     || d.Quantity.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                    )
                    .ToList();
            }

            // 3) PageVm oluştur
            var pageVm = new PackageExtraIndexPageVm
            {
                Request = new PackageExtraIndexRequestModel { SearchTerm = searchTerm },
                Response = new PackageExtraIndexResponseModel { PackageExtras = list }
            };

            return View(pageVm);
        }

        #endregion

        #region PackageExtraCreateAction

        /// <summary>
        /// Yeni paket-ekstra oluşturma formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            var pageVm = new PackageExtraCreatePageVm();

            // Sadece aktif paket seçeneklerini getir
            var pOpts = await _packageOptionManager.GetAllAsync();
            pageVm.PackageOptions = pOpts
                .Where(p => p.Status != DataStatus.Deleted)
                .Select(p => new SelectListItem(p.Name, p.Id.ToString()))
                .ToList();

            // Sadece aktif ekstra hizmetleri getir
            var eSvcs = await _extraServiceManager.GetAllAsync();
            pageVm.ExtraServices = eSvcs
                .Where(e => e.Status != DataStatus.Deleted)
                .Select(e => new SelectListItem(e.Name, e.Id.ToString()))
                .ToList();

            return View(pageVm);
        }

        /// <summary>
        /// Formdan gelen verilerle yeni paket-ekstra kaydı oluşturur.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PackageExtraCreatePageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                // Dropdown’ları tekrar doldur
                var pOpts = await _packageOptionManager.GetAllAsync();
                pageVm.PackageOptions = pOpts
                    .Where(p => p.Status != DataStatus.Deleted)
                    .Select(p => new SelectListItem(p.Name, p.Id.ToString()))
                    .ToList();
                var eSvcs = await _extraServiceManager.GetAllAsync();
                pageVm.ExtraServices = eSvcs
                    .Where(e => e.Status != DataStatus.Deleted)
                    .Select(e => new SelectListItem(e.Name, e.Id.ToString()))
                    .ToList();

                return View(pageVm);
            }

            var dto = new PackageExtraDto
            {
                PackageOptionId = pageVm.Request.PackageOptionId,
                ExtraServiceId = pageVm.Request.ExtraServiceId,
                Quantity = pageVm.Request.Quantity,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            try
            {
                await _packageExtraManager.CreateAsync(dto);
                TempData["SuccessMessage"] = "Paket ekstra başarıyla eklendi.";
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

        #region PackageExtraEditAction

        /// <summary>
        /// Mevcut kaydı düzenleme formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _packageExtraManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            // Dropdown'lar için paket seçenekleri
            var pOpts = await _packageOptionManager.GetAllAsync();
            // Dropdown'lar için ekstra hizmetler
            var eSvcs = await _extraServiceManager.GetAllAsync();

            var pageVm = new PackageExtraEditPageVm
            {
                Request = new PackageExtraEditRequestModel
                {
                    Id = dto.Id,
                    PackageOptionId = dto.PackageOptionId,
                    ExtraServiceId = dto.ExtraServiceId,
                    Quantity = dto.Quantity
                },
                PackageOptions = pOpts
                    .Where(p => p.Status != DataStatus.Deleted)
                    .Select(p => new SelectListItem(p.Name, p.Id.ToString()))
                    .ToList(),
                ExtraServices = eSvcs
                    .Where(e => e.Status != DataStatus.Deleted)
                    .Select(e => new SelectListItem(e.Name, e.Id.ToString()))
                    .ToList()
            };

            return View(pageVm);
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle kaydı günceller.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PackageExtraEditPageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                // Dropdown'ları yeniden yükle
                var pOpts = await _packageOptionManager.GetAllAsync();
                var eSvcs = await _extraServiceManager.GetAllAsync();
                pageVm.PackageOptions = pOpts
                    .Where(p => p.Status != DataStatus.Deleted)
                    .Select(p => new SelectListItem(p.Name, p.Id.ToString()))
                    .ToList();
                pageVm.ExtraServices = eSvcs
                    .Where(e => e.Status != DataStatus.Deleted)
                    .Select(e => new SelectListItem(e.Name, e.Id.ToString()))
                    .ToList();
                return View(pageVm);
            }

            var existing = await _packageExtraManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null)
                return NotFound();

            var dto = new PackageExtraDto
            {
                Id = pageVm.Request.Id,
                PackageOptionId = pageVm.Request.PackageOptionId,
                ExtraServiceId = pageVm.Request.ExtraServiceId,
                Quantity = pageVm.Request.Quantity,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _packageExtraManager.UpdateAsync(dto);
                TempData["SuccessMessage"] = "Paket-extra başarıyla güncellendi.";
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

        #region PackageExtraDeleteAction

        /// <summary>
        /// Silme onayı için mevcut paket-ekstra kaydını görüntüler.
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _packageExtraManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new PackageExtraDeletePageVm
            {
                Request = new PackageExtraDeleteRequestModel
                {
                    Id = dto.Id,
                    Description = $"PaketOption: {dto.PackageOptionId}, ExtraService: {dto.ExtraServiceId}, Adet: {dto.Quantity}"
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Paket-ekstra kaydını soft-delete ile silinmiş olarak işaretler.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PackageExtraDeletePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = await _packageExtraManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            await _packageExtraManager.MakePassiveAsync(new PackageExtraDto { Id = dto.Id });

            TempData["SuccessMessage"] = "Paket-ekstra başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}
