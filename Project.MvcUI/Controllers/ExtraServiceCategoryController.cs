using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PageVms.ExtraServiceCategories;
using Project.MvcUI.Models.PureVms.RequestModels.ExtraServiceCategories;
using Project.MvcUI.Models.PureVms.ResponseModels.ExtraServiceCategories;

namespace Project.MvcUI.Controllers
{
    [Authorize]
    public class ExtraServiceCategoryController : Controller
    {
        private readonly IExtraServiceCategoryManager _categoryManager;

        public ExtraServiceCategoryController(IExtraServiceCategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        #region ExtraServiceCategoryIndexAction

        // <summary>
        /// Ekstra hizmet kategorilerini listeler; isteğe bağlı ad filtresi uygular.
        /// </summary>
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // BLL'den tüm kategorileri al
            List<ExtraServiceCategoryDto> list = await _categoryManager.GetAllAsync();

            // 2Arama terimi varsa in-memory filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                list = list
                    .Where(c => c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // 3) PageVm'i oluştur ve view'a gönder
            ExtraServiceCategoryIndexPageVm pageVm = new() 
            {
                Request = new ExtraServiceCategoryIndexRequestModel { SearchTerm = searchTerm },
                Response = new ExtraServiceCategoryIndexResponseModel { Categories = list }
            };

            return View(pageVm);
        }

        #endregion

        #region ExtraServiceCategoryCreateAction

        /// <summary>
        /// Yeni ekstra hizmet kategorisi ekleme formunu görüntüler.
        /// </summary>
        public IActionResult Create()
        {
            ExtraServiceCategoryCreatePageVm pageVm = new();
            return View(pageVm);
        }

        /// <summary>
        /// Yeni ekstra hizmet kategorisi oluşturma işlemini gerçekleştirir.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExtraServiceCategoryCreatePageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm);

            ExtraServiceCategoryDto dto = new() 
            {
                Name = pageVm.Request.Name,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            try
            {
                await _categoryManager.CreateAsync(dto);
                TempData["SuccessMessage"] = "Kategori başarıyla eklendi.";
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

        #region ExtraServiceCategoryEditAction

        /// <summary>
        /// Mevcut ekstra hizmet kategorisi düzenleme formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            ExtraServiceCategoryDto dto = await _categoryManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound();

            ExtraServiceCategoryEditPageVm pageVm = new() 
            {
                Request = new ExtraServiceCategoryEditRequestModel
                {
                    Id = dto.Id,
                    Name = dto.Name
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Ekstra hizmet kategorisi düzenleme işlemini gerçekleştirir.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExtraServiceCategoryEditPageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm);

            ExtraServiceCategoryDto existing = await _categoryManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null) return NotFound();

            ExtraServiceCategoryDto dto = new()
            {
                Id = pageVm.Request.Id,
                Name = pageVm.Request.Name,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _categoryManager.UpdateAsync(dto);
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

        #region ExtraServiceCategoryDeleteAction

        /// <summary>
        /// Kategori silme onay ekranını gösterir.
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            ExtraServiceCategoryDto dto = await _categoryManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound();

            ExtraServiceCategoryDeletePageVm pageVm = new()
            {
                Request = new ExtraServiceCategoryDeleteRequestModel
                {
                    Id = dto.Id,
                    Name = dto.Name
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Kategoriyi soft-delete ile silinmiş olarak işaretler.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ExtraServiceCategoryDeletePageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm);

            ExtraServiceCategoryDto dto = await _categoryManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound();

            await _categoryManager.MakePassiveAsync(new ExtraServiceCategoryDto
            {
                Id = pageVm.Request.Id
            });

            TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
