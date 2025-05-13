using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.SizeOptions;
using Project.MvcUI.Models.PureVms.RequestModels.SizeOptions;
using Project.MvcUI.Models.PureVms.ResponseModels.SizeOptions;

namespace Project.MvcUI.Controllers
{
    public class SizeOptionController : Controller
    {
        readonly ISizeOptionManager _sizeOptionManager;  // BLL manager 
        readonly IServiceCategoryManager _serviceCategoryManager;


        public SizeOptionController(ISizeOptionManager sizeOptionManager, IServiceCategoryManager serviceCategoryManager)
        {
            _sizeOptionManager = sizeOptionManager;
            _serviceCategoryManager = serviceCategoryManager;
        }

        #region SizeOptionIndexAction

        /// <summary>
        /// Ölçü seçeneklerini listeler; isteğe bağlı olarak dimension üzerinden arama yapar.
        /// </summary>
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // 1) Tüm kayıtları al
            var list = await _sizeOptionManager.GetAllAsync();

            // 2) Arama terimi varsa in-memory filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                list = list
                    .Where(d => d.Dimension
                        .Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // 3) PageVm’i oluştur
            var pageVm = new SizeOptionIndexPageVm
            {
                Request = new SizeOptionIndexRequestModel { SearchTerm = searchTerm },
                Response = new SizeOptionIndexResponseModel { SizeOptions = list }
            };

            return View(pageVm);
        }

        #endregion

        #region SizeOptionCreateAction

        /// <summary>
        /// Yeni ölçü seçeneği ekleme formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            var pageVm = new SizeOptionCreatePageVm();

            // Sadece silinmemiş kategorileri al
            var cats = await _serviceCategoryManager.GetAllAsync();
            pageVm.ServiceCategories = cats
                .Where(c => c.Status != DataStatus.Deleted)
                .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                .ToList();

            return View(pageVm);
        }

        /// <summary>
        /// Formdan gelen verilerle yeni ölçü seçeneği oluşturur.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SizeOptionCreatePageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                // Dropdown’ları tekrar doldur
                var cats = await _serviceCategoryManager.GetAllAsync();
                pageVm.ServiceCategories = cats
                    .Where(c => c.Status != DataStatus.Deleted)
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList();
                return View(pageVm);
            }

            var dto = new SizeOptionDto
            {
                ServiceCategoryId = pageVm.Request.ServiceCategoryId,
                Dimension = pageVm.Request.Dimension,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            try
            {
                await _sizeOptionManager.CreateAsync(dto);
                TempData["SuccessMessage"] = "Ölçü seçeneği başarıyla eklendi.";
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

        #region SizeOptionEditAction

        /// <summary>
        /// Mevcut ölçü seçeneği düzenleme formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _sizeOptionManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var cats = await _serviceCategoryManager.GetAllAsync();

            var pageVm = new SizeOptionEditPageVm
            {
                Request = new SizeOptionEditRequestModel
                {
                    Id = dto.Id,
                    ServiceCategoryId = dto.ServiceCategoryId,
                    Dimension = dto.Dimension
                },
                ServiceCategories = cats
                    .Where(c => c.Status != DataStatus.Deleted)
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList()
            };

            return View(pageVm);
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle ölçü seçeneğini günceller.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SizeOptionEditPageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                var cats = await _serviceCategoryManager.GetAllAsync();
                pageVm.ServiceCategories = cats
                    .Where(c => c.Status != DataStatus.Deleted)
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList();
                return View(pageVm);
            }

            var existing = await _sizeOptionManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null)
                return NotFound();

            var dto = new SizeOptionDto
            {
                Id = pageVm.Request.Id,
                ServiceCategoryId = pageVm.Request.ServiceCategoryId,
                Dimension = pageVm.Request.Dimension,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _sizeOptionManager.UpdateAsync(dto);
                TempData["SuccessMessage"] = "Ölçü seçeneği başarıyla güncellendi.";
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

        #region SizeOptionDeleteAction

        /// <summary>
        /// Ölçü seçeneği silme onay ekranını görüntüler.
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _sizeOptionManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new SizeOptionDeletePageVm
            {
                Request = new SizeOptionDeleteRequestModel
                {
                    Id = dto.Id,
                    Dimension = dto.Dimension
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Ölçü seçeneğini soft-delete ile silinmiş olarak işaretler.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SizeOptionDeletePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = await _sizeOptionManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            await _sizeOptionManager.MakePassiveAsync(new SizeOptionDto { Id = dto.Id });

            TempData["SuccessMessage"] = "Ölçü seçeneği başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
