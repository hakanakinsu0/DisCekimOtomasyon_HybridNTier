using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PageVms.Photographers;
using Project.MvcUI.Models.PureVms.RequestModels.Photographers;
using Project.MvcUI.Models.PureVms.ResponseModel.Photographers;
using System.Collections.Generic;

namespace Project.MvcUI.Controllers
{
    public class PhotographerController : Controller
    {
        readonly IPhotographerManager _photographerManager;

        public PhotographerController(IPhotographerManager photographerManager)
        {
            _photographerManager = photographerManager;
        }

        #region PhotographerIndexAction

        /// <summary>
        /// Fotoğrafçı listesini görüntüler; isteğe bağlı olarak ad-soyad araması yapar.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // BLL'den silinmiş durumu ve arama terimini de dikkate alarak fotoğrafçıları al
            List<PhotographerDto> photographers = await _photographerManager.GetAllWithFilterAsync(searchTerm);

            // PageVm'i oluştur ve view'a gönder
            PhotographerIndexPageVm pageVm = new() 
            {
                Request = new PhotographerIndexRequestModel { SearchTerm = searchTerm },
                Response = new PhotographerIndexResponseModel { Photographers = photographers }
            };
            return View(pageVm);
        }

        #endregion

        #region PhotographerCreateAction

        /// <summary>
        /// Yeni fotoğrafçı ekleme formunu görüntüler.
        /// </summary>
        [Authorize]
        public IActionResult Create()
        {
            // Create sayfası için boş bir PageVm hazırlaması
            PhotographerCreatePageVm pageVm = new() 
            {
                Request = new PhotographerCreateRequestModel(), // Boş istek modeli
                Response = new PhotographerCreateResponseModel() // Boş cevap modeli
            };
            return View(pageVm);
        }

        /// <summary>
        /// Yeni fotoğrafçı ekleme işlemini gerçekleştirir.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhotographerCreatePageVm pageVm)
        {
            if (!ModelState.IsValid) // ModelState validasyonunu kontrol et
                return View(pageVm); // Hatalıysa formu tekrar göster

            // RequestModel'den DTO'ya dönüştürme
            PhotographerDto dto = new() 
            {
                FirstName = pageVm.Request.FirstName,
                LastName = pageVm.Request.LastName,
                Phone = pageVm.Request.Phone,
                Fee = pageVm.Request.Fee,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _photographerManager.CreateAsync(dto); // BLL aracılığıyla veri ekle

            TempData["SuccessMessage"] = "Fotoğrafçı başarıyla eklendi."; // Başarı mesajı
            return RedirectToAction("Index"); // ACtion'a yönlendir
        }

        #endregion

        #region PhotographerEditAction

        /// <summary>
        /// Var olan bir fotoğrafçının bilgilerini düzenleme formunu görüntüler.
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            PhotographerDto dto = await _photographerManager.GetByIdAsync(id); // BLL'den veri al
            if (dto == null) return NotFound();

            // Düzenleme formu için PageVm oluştur
            PhotographerEditPageVm pageVm = new() 
            {
                Request = new PhotographerEditRequestModel
                {
                    Id = dto.Id,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Phone = dto.Phone,
                    Fee = dto.Fee
                },
                Response = new PhotographerEditResponseModel() // Boş cevap modeli
            };

            return View(pageVm);
        }

        /// <summary>
        /// Fotoğrafçı düzenleme işlemini gerçekleştirir.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PhotographerEditPageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm); // ModelState kontrolü

            PhotographerDto existing = await _photographerManager.GetByIdAsync(pageVm.Request.Id); // Mevcut kaydı al
            if (existing == null) return NotFound(); // Yoksa 404

            // Yeni DTO oluştur, mevcut CreatedDate'i korur
            PhotographerDto dto = new() 
            {
                Id = pageVm.Request.Id,
                FirstName = pageVm.Request.FirstName,
                LastName = pageVm.Request.LastName,
                Phone = pageVm.Request.Phone,
                Fee = pageVm.Request.Fee,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _photographerManager.UpdateAsync(dto); // BLL aracılığıyla güncelle

                TempData["SuccessMessage"] = "Fotoğrafçı başarıyla güncellendi."; // Başarı mesajı
                return RedirectToAction("Index"); // Listeye dön
            }
            catch (Exception ex)
            {
                pageVm.Response.IsSuccess = false;        // Hata durumunu ayarla
                pageVm.Response.ErrorMessage = ex.Message; // Hata mesajını ata
                return View(pageVm); // Formu hata mesajıyla tekrar göster
            }
        }
        #endregion

        #region PhotographerDeleteAction

        /// <summary>
        /// Fotoğrafçı silme onay sayfasını görüntüler.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            PhotographerDto dto = await _photographerManager.GetByIdAsync(id); // Mevcut kaydı al
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound(); // Yoksa veya zaten silinmişse 404

            // Silme onayı için PageVm oluştur
            PhotographerDeletePageVm pageVm = new()
            {
                Request = new PhotographerDeleteRequestModel
                {
                    Id = dto.Id,
                    FullName = $"{dto.FirstName} {dto.LastName}" // Kullanıcıya gösterilecek isim
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Fotoğrafçıyı soft-delete (silinmiş) olarak işaretler.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PhotographerDeletePageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm); // ModelState kontrolü

            PhotographerDto dto = await _photographerManager.GetByIdAsync(pageVm.Request.Id); // Kaydı al
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound(); // Yoksa veya zaten silinmişse 404

            await _photographerManager.MakePassiveAsync(new PhotographerDto { Id = pageVm.Request.Id }); // BLL ile soft-delete

            TempData["SuccessMessage"] = "Fotoğrafçı başarıyla silindi."; // Başarı mesajı
            return RedirectToAction("Index"); 
        }

        #endregion
    }
}
