using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PageVms.ExtraServices;
using Project.MvcUI.Models.PureVms.RequestModels.ExtraServices;
using Project.MvcUI.Models.PureVms.ResponseModels.ExtraServices;

namespace Project.MvcUI.Controllers
{
    public class ExtraServiceController : Controller
    {
        readonly IExtraServiceManager _extraServiceManager;
        readonly IExtraServiceCategoryManager _categoryManager;


        public ExtraServiceController(IExtraServiceManager extraServiceManager, IExtraServiceCategoryManager categoryManager)
        {
            _extraServiceManager = extraServiceManager;
            _categoryManager = categoryManager;
        }

        #region ExtraServiceIndexAction

        /// <summary>
        /// Ekstra hizmetler listesini getirir; ad veya fiyat filtresi uygular.
        /// </summary>
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // BLL’den tüm kayıtları al
            List<ExtraServiceDto> list = await _extraServiceManager.GetAllAsync();

            // Arama terimi varsa in-memory filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                list = list
                    .Where(x =>
                        x.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                        || x.Price.ToString("N2").Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                    )
                    .ToList();
            }

            // PageVm’i oluştur
            ExtraServiceIndexPageVm pageVm = new() 
            {
                Request = new ExtraServiceIndexRequestModel { SearchTerm = searchTerm },
                Response = new ExtraServiceIndexResponseModel { ExtraServices = list }
            };

            return View(pageVm);

        }
        #endregion

        #region ExtraServiceCreateAction

        public async Task<IActionResult> Create()
        {
            // Sadece silinmemiş (Status != Deleted) kategorileri al
            List<ExtraServiceCategoryDto> cats = (await _categoryManager.GetAllAsync())
                           .Where(c => c.Status != DataStatus.Deleted)
                           .ToList();

            // PageVm’i oluştur ve dropdown listesini ata
            ExtraServiceCreatePageVm pageVm = new() 
            {
                Categories = cats
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList()
            };

            return View(pageVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExtraServiceCreatePageVm pageVm)
        {
            // Eğer validasyon başarısızsa dropdown’u tekrar doldurmamız gerek
            if (!ModelState.IsValid)
            {
                List<ExtraServiceCategoryDto> cats = await _categoryManager.GetAllAsync();
                pageVm.Categories = cats.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
                return View(pageVm);
            }

            ExtraServiceDto dto = new() 
            {
                ExtraServiceCategoryId = pageVm.Request.ExtraServiceCategoryId, // Seçilen kategori
                Name = pageVm.Request.Name,
                Price = pageVm.Request.Price,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _extraServiceManager.CreateAsync(dto);
            TempData["SuccessMessage"] = "Ekstra hizmet başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region ExtraServiceEditAction

        /// <summary>
        /// Mevcut ekstra hizmetin düzenleme formunu görüntüler.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            // Güncellenecek kaydı getir
            ExtraServiceDto dto = await _extraServiceManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            // Sadece silinmemiş kategorileri al
            List<ExtraServiceCategoryDto> cats = (await _categoryManager.GetAllAsync())
                           .Where(c => c.Status != DataStatus.Deleted)
                           .ToList();

            // PageVm’i oluştur ve formu doldur
            ExtraServiceEditPageVm pageVm = new() 
            {
                Request = new ExtraServiceEditRequestModel
                {
                    Id = dto.Id,
                    ExtraServiceCategoryId = dto.ExtraServiceCategoryId,
                    Name = dto.Name,
                    Price = dto.Price
                },
                Categories = cats
                    .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                    .ToList()
            };

            return View(pageVm);
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle ekstra hizmeti günceller.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExtraServiceEditPageVm pageVm)
        {
            if (!ModelState.IsValid)
            {
                List<ExtraServiceCategoryDto> cats = await _categoryManager.GetAllAsync();
                pageVm.Categories = cats.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
                return View(pageVm);
            }

            ExtraServiceDto existing = await _extraServiceManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null) return NotFound();

            ExtraServiceDto dto = new()
            {
                Id = pageVm.Request.Id,
                ExtraServiceCategoryId = pageVm.Request.ExtraServiceCategoryId,
                Name = pageVm.Request.Name,
                Price = pageVm.Request.Price,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _extraServiceManager.UpdateAsync(dto);
                TempData["SuccessMessage"] = "Ekstra hizmet başarıyla güncellendi.";
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

        #region ExtraServiceDeleteAction

        /// <summary>
        /// Silme onay sayfasını gösterir.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            ExtraServiceDto dto = await _extraServiceManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound();

            ExtraServiceDeletePageVm pageVm = new()
            {
                Request = new ExtraServiceDeleteRequestModel
                {
                    Id = dto.Id,
                    Name = dto.Name
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Ekstra hizmeti soft-delete ile silinmiş olarak işaretler.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ExtraServiceDeletePageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm);

            ExtraServiceDto dto = await _extraServiceManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound();

            await _extraServiceManager.MakePassiveAsync(new ExtraServiceDto { Id = pageVm.Request.Id });

            TempData["SuccessMessage"] = "Ekstra hizmet başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
