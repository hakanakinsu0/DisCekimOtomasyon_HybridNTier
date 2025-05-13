using Microsoft.AspNetCore.Mvc;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.PackageOptions;
using Project.MvcUI.Models.PureVms.RequestModels.PackageOptions;
using Project.MvcUI.Models.PureVms.ResponseModels.PackageOptions;

namespace Project.MvcUI.Controllers
{
    public class PackageOptionController : Controller
    {
        readonly IPackageOptionManager _packageOptionManager;

        public PackageOptionController(IPackageOptionManager packageOptionManager)
        {
            _packageOptionManager = packageOptionManager;
        }

        #region PackageOptionIndexAction

        /// <summary>
        /// Paket seçenekleri listesini getirir; isteğe bağlı ad veya fiyat filtresi uygular.
        /// </summary>
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // 1) BLL’den tüm paket seçeneklerini al
            var list = await _packageOptionManager.GetAllAsync();

            // 2) Arama terimi varsa in‐memory filtre uygula (Ad veya Fiyat)
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                list = list
                    .Where(x =>
                        x.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        x.Price.ToString("N2").Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                    )
                    .ToList();
            }

            // 3) PageVm’i oluştur ve view’a gönder
            var pageVm = new PackageOptionIndexPageVm
            {
                Request = new PackageOptionIndexRequestModel { SearchTerm = searchTerm },
                Response = new PackageOptionIndexResponseModel { PackageOptions = list }
            };

            return View(pageVm);
        }

        #endregion

        #region PackageOptionCreateAction

        public IActionResult Create()
        {
            var pageVm = new PackageOptionCreatePageVm();
            return View(pageVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PackageOptionCreatePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = new PackageOptionDto
            {
                Name = pageVm.Request.Name,
                Price = pageVm.Request.Price,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            try
            {
                await _packageOptionManager.CreateAsync(dto);
                TempData["SuccessMessage"] = "Paket seçeneği başarıyla eklendi.";
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

        #region PackageOptionEditAction

        /// <summary>
        /// Mevcut paket seçeneği düzenleme formunu görüntüler.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _packageOptionManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new PackageOptionEditPageVm
            {
                Request = new PackageOptionEditRequestModel
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Price = dto.Price
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle paket seçeneğini günceller.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PackageOptionEditPageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var existing = await _packageOptionManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null)
                return NotFound();

            var dto = new PackageOptionDto
            {
                Id = pageVm.Request.Id,
                Name = pageVm.Request.Name,
                Price = pageVm.Request.Price,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _packageOptionManager.UpdateAsync(dto);
                TempData["SuccessMessage"] = "Paket seçeneği başarıyla güncellendi.";
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

        #region PackageOptionDeleteAction

        /// <summary>
        /// Paket seçeneği silme onay ekranını gösterir.
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _packageOptionManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new PackageOptionDeletePageVm
            {
                Request = new PackageOptionDeleteRequestModel
                {
                    Id = dto.Id,
                    Name = dto.Name
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Paket seçeneğini soft-delete ile “silinmiş” olarak işaretler.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PackageOptionDeletePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = await _packageOptionManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            // Soft-delete: Status ve DeletedDate otomatik MakePassiveAsync içinde ayarlanır
            await _packageOptionManager.MakePassiveAsync(new PackageOptionDto { Id = dto.Id });

            TempData["SuccessMessage"] = "Paket seçeneği başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
