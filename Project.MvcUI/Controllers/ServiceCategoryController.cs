using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.ServiceCategories;
using Project.MvcUI.Models.PureVms.RequestModels.ServiceCategories;
using Project.MvcUI.Models.PureVms.ResponseModels.ServiceCategories;

namespace Project.MvcUI.Controllers
{
    [Authorize]

    public class ServiceCategoryController : Controller
    {
        readonly IServiceCategoryManager _serviceCategoryManager;
        readonly IAlbumCompanyManager _albumCompanyManager;

        public ServiceCategoryController(IServiceCategoryManager serviceCategoryManager, IAlbumCompanyManager albumCompanyManager)
        {
            _serviceCategoryManager = serviceCategoryManager;
            _albumCompanyManager = albumCompanyManager;
        }

        #region ServiceCategoryIndexAction

        /// <summary>
        /// Servis kategorileri listesini getirir; isteğe bağlı ad filtresi uygular.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // BLL’den tüm kategorileri al
            var list = await _serviceCategoryManager.GetAllAsync();

            // Arama terimi varsa in-memory filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                list = list
                    .Where(c => c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // PageVm’i oluştur ve view’a gönder
            var pageVm = new ServiceCategoryIndexPageVm
            {
                Request = new ServiceCategoryIndexRequestModel { SearchTerm = searchTerm },
                Response = new ServiceCategoryIndexResponseModel { Categories = list }
            };

            return View(pageVm);
        }

        #endregion

        #region ServiceCategoryCreateAction

        /// <summary>
        /// Yeni servis kategorisi oluşturma formunu görüntüler.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companies = await _albumCompanyManager.GetAllAsync();  // Seed’lediğimiz
            var pageVm = new ServiceCategoryCreatePageVm
            {
                Companies = companies
                    .Where(c => c.Status != DataStatus.Deleted)
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList()
            };
            return View(pageVm);
        }

        /// <summary>
        /// Yeni servis kategorisi oluşturur.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceCategoryCreatePageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                // Dropdown’u yeniden doldur
                var companies = await _albumCompanyManager.GetAllAsync();
                pageVm.Companies = companies
                    .Where(c => c.Status != DataStatus.Deleted)
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList();
                return View(pageVm);
            }

            var dto = new ServiceCategoryDto
            {
                AlbumCompanyId = pageVm.Request.AlbumCompanyId, // Burayı ekledik
                Name = pageVm.Request.Name,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _serviceCategoryManager.CreateAsync(dto);
            TempData["SuccessMessage"] = "Kategori başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region ServiceCategoryEditAction

        /// <summary>
        /// Servis kategorisi düzenleme formunu görüntüler.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _serviceCategoryManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var companies = await _albumCompanyManager.GetAllAsync();
            var pageVm = new ServiceCategoryEditPageVm
            {
                Request = new ServiceCategoryEditRequestModel
                {
                    Id = dto.Id,
                    AlbumCompanyId = dto.AlbumCompanyId,
                    Name = dto.Name
                },
                Companies = companies
                    .Where(c => c.Status != DataStatus.Deleted)
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList()
            };
            return View(pageVm);
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle servis kategorisini günceller.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceCategoryEditPageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                var companies = await _albumCompanyManager.GetAllAsync();
                pageVm.Companies = companies
                    .Where(c => c.Status != DataStatus.Deleted)
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList();
                return View(pageVm);
            }

            var existing = await _serviceCategoryManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null)
                return NotFound();

            var dto = new ServiceCategoryDto
            {
                Id = pageVm.Request.Id,
                AlbumCompanyId = pageVm.Request.AlbumCompanyId,
                Name = pageVm.Request.Name,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _serviceCategoryManager.UpdateAsync(dto);
                TempData["SuccessMessage"] = "Kategori başarıyla güncellendi.";
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

        #region ServiceCategoryDeleteAction

        /// <summary>
        /// Servis kategorisi silme onay sayfasını gösterir.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _serviceCategoryManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new ServiceCategoryDeletePageVm
            {
                Request = new ServiceCategoryDeleteRequestModel
                {
                    Id = dto.Id,
                    Name = dto.Name
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Servis kategorisini soft-delete ile silinmiş olarak işaretler.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ServiceCategoryDeletePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = await _serviceCategoryManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            await _serviceCategoryManager.MakePassiveAsync(new Project.BLL.DtoClasses.ServiceCategoryDto
            {
                Id = pageVm.Request.Id
            });

            TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
