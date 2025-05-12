using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.Locations;
using Project.MvcUI.Models.PureVms.RequestModels.Locations;
using Project.MvcUI.Models.PureVms.ResponseModels.Locations;

namespace Project.MvcUI.Controllers
{
    public class LocationController : Controller
    {
        readonly ILocationManager _locationManager;

        public LocationController(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }

        #region LocationIndexAction

        /// <summary>
        /// Mekan listesini getirir; isteğe bağlı mekan adı veya açıklama filtresi uygular.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // BLL'den soft-delete durumu da dahil tüm mekanları, arama kriterine göre filtreleyerek al
            List<LocationDto> locations = await _locationManager.GetAllWithFilterAsync(searchTerm);

            // PageVm'i oluştur ve view'a gönder
            LocationIndexPageVm pageVm = new()
            {
                Request = new LocationIndexRequestModel { SearchTerm = searchTerm }, // Arama terimini atar
                Response = new LocationIndexResponseModel { Locations = locations }   // Listeyi atar
            };
            return View(pageVm); // Index.cshtml'i render eder
        }

        #endregion

        #region LocationCreateAction

        /// <summary>
        /// Yeni mekan ekleme formunu görüntüler.
        /// </summary>
        [Authorize]
        public IActionResult Create()
        {
            LocationCreatePageVm pageVm = new(); // Boş PageVm hazırla
            return View(pageVm);                 // Create.cshtml'i render et
        }

        /// <summary>
        /// Yeni mekan ekleme işlemini gerçekleştirir.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LocationCreatePageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm); // Validasyon hatalıysa formu tekrar göster

            // RequestModel → DTO dönüşümü
            LocationDto dto = new()
            {
                Name = pageVm.Request.Name,
                Address = pageVm.Request.Address,
                District = pageVm.Request.District,
                City = pageVm.Request.City,
                Phone = pageVm.Request.Phone,
                IsFree = pageVm.Request.IsFree,
                Price = pageVm.Request.Price,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            try
            {
                await _locationManager.CreateAsync(dto); // BLL üzerinden ekle
                TempData["SuccessMessage"] = "Mekan başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Hata durumunda ResponseModel'i doldur
                pageVm.Response.IsSuccess = false;
                pageVm.Response.ErrorMessage = ex.Message;
                return View(pageVm);
            }
        }

        #endregion

        #region LocationEditAction

        /// <summary>
        /// Mevcut bir mekanın düzenleme formunu görüntüler.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            LocationDto dto = await _locationManager.GetByIdAsync(id);            // BLL’den kaydı al
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound(); // Bulunmaz veya silinmişse

            // Düzenleme VM’i oluştur ve verileri ata
            LocationEditPageVm pageVm = new()
            {
                Request = new LocationEditRequestModel
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Address = dto.Address,
                    District = dto.District,
                    City = dto.City,
                    Phone = dto.Phone,
                    IsFree = dto.IsFree,
                    Price = dto.Price
                },
                Response = new LocationEditResponseModel()                // Başlangıçta boş
            };

            return View(pageVm);                                        // Edit.cshtml’i render et
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle mekanı günceller.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LocationEditPageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm);                                     // Validasyon hatalıysa formu tekrar göster

            LocationDto existing = await _locationManager.GetByIdAsync(pageVm.Request.Id); // Mevcut kaydı al
            if (existing == null) return NotFound();

            // DTO’yu oluştur, CreatedDate’i koru, ModifiedDate’i güncelle, durumu güncelle
            LocationDto dto = new() 
            {
                Id = pageVm.Request.Id,
                Name = pageVm.Request.Name,
                Address = pageVm.Request.Address,
                District = pageVm.Request.District,
                City = pageVm.Request.City,
                Phone = pageVm.Request.Phone,
                IsFree = pageVm.Request.IsFree,
                Price = pageVm.Request.Price,
                CreatedDate = existing.CreatedDate,                      // Eski oluşturma tarihini koru
                ModifiedDate = DateTime.Now,                              // Güncelleme tarihini ayarla
                Status = DataStatus.Updated                         // Durumu güncellenmiş yap
            };

            try
            {
                await _locationManager.UpdateAsync(dto);                  // BLL ile güncelle

                TempData["SuccessMessage"] = "Mekan başarıyla güncellendi."; // Başarı mesajı
                return RedirectToAction(nameof(Index));                   // Listeye dön
            }
            catch (Exception ex)
            {
                pageVm.Response.IsSuccess = false;                    // Hata durumu
                pageVm.Response.ErrorMessage = ex.Message;               // Hata mesajı
                return View(pageVm);                                     // Formu hata ile tekrar göster
            }
        }

        #endregion

        #region LocationDeleteAction

        /// <summary>
        /// Silinecek mekan için onay sayfasını gösterir.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            // BLL’den kaydı getir
            LocationDto dto = await _locationManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound();

            // Silme onayı için VM hazırla
            LocationDeletePageVm pageVm = new() 
            {
                Request = new LocationDeleteRequestModel
                {
                    Id = dto.Id,
                    Name = dto.Name
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Mekanı soft-delete olarak işaretler.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(LocationDeletePageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm);

            // BLL’den mevcut kaydı al
            LocationDto dto = await _locationManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound();

            // Soft-delete: Status=Deleted, DeletedDate ataması
            await _locationManager.MakePassiveAsync(new LocationDto { Id = pageVm.Request.Id });

            TempData["SuccessMessage"] = "Mekan başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
