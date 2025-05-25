using MailKit.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.Customers;
using Project.MvcUI.Models.PureVms.RequestModels.Customers;
using Project.MvcUI.Models.PureVms.ResponseModels.Customers;

namespace Project.MvcUI.Controllers
{
    public class CustomerController : Controller
    {
        readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        #region CustomerIndexAction

        /// <summary>
        /// Müşteri listesini getirir; isteğe bağlı ad/soyad/e-posta filtresi uygular.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // BLL'den silinmişleri de dahil tüm müşterileri, arama kriterine göre filtreleyerek al
            List<CustomerDto> customers = await _customerManager.GetAllWithFilterAsync(searchTerm);

            // PageVm'i oluştur ve view'a gönder
            CustomerIndexPageVm pageVm = new()
            {
                Request = new CustomerIndexRequestModel { SearchTerm = searchTerm },  // Arama terimini atar
                Response = new CustomerIndexResponseModel { Customers = customers } // Listeyi atar
            };
            return View(pageVm); // Index.cshtml'i render eder
        }

        #endregion

        #region CustomerCreateAction

        /// <summary>
        /// Yeni müşteri ekleme formunu gösterir.
        /// </summary>
        [Authorize]
        public IActionResult Create(string returnUrl)
        {
            // Eğer Rezervasyondan gelindiyse, returnUrl="/Reservation/Create" olur
            // Direkt /Customer/Create’te returnUrl null
            var pageVm = new CustomerCreatePageVm
            {
                ReturnUrl = returnUrl
            };
            return View(pageVm);
        }

        /// <summary>
        /// Yeni müşteri ekleme işlemini gerçekleştirir.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreatePageVm pageVm)
        {
            // Validasyon hatası varsa formu tekrar göster (ReturnUrl pageVm içinde var)
            if (!ModelState.IsValid)
                return View(pageVm);

            // DTO’ya dönüşüm
            var dto = new CustomerDto
            {
                BrideName = pageVm.Request.BrideName,
                GroomName = pageVm.Request.GroomName,
                LastName = pageVm.Request.LastName,
                Phone1 = pageVm.Request.Phone1,
                Phone2 = pageVm.Request.Phone2,
                Email = pageVm.Request.Email,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            try
            {
                await _customerManager.CreateAsync(dto);
                TempData["SuccessMessage"] = "Müşteri başarıyla eklendi.";

                // Akışa göre yönlendir:
                // 1) Rezervasyondan gelindiyse => Rezervasyon Oluştur sayfasına dön
                if (!string.IsNullOrWhiteSpace(pageVm.ReturnUrl))
                    return RedirectToAction("Create", "Reservation");

                // 2) Direkt Customer/Create ise => Customer/Index’e dön
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

        #region CustomerEditAction

        /// <summary>
        /// Mevcut bir müşteriyi düzenlemek için formu doldurarak görüntüler.
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            CustomerDto dto = await _customerManager.GetByIdAsync(id);    // BLL’den kaydı al
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound(); // Bulunmaz veya silinmişse

            // PageVm’i oluştur ve verileri at
            CustomerEditPageVm pageVm = new CustomerEditPageVm
            {
                Request = new CustomerEditRequestModel
                {
                    Id = dto.Id,
                    BrideName = dto.BrideName,
                    GroomName = dto.GroomName,
                    LastName = dto.LastName,
                    Phone1 = dto.Phone1,
                    Phone2 = dto.Phone2,
                    Email = dto.Email
                },
                Response = new CustomerEditResponseModel() // Başlangıçta boş
            };

            return View(pageVm); // Edit.cshtml’i render et
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle müşteriyi günceller.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerEditPageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm); // Validasyon hatası

            // Var olan kaydı çek ve CreatedDate’i koru
            CustomerDto existing = await _customerManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null)
                return NotFound();

            // DTO’yu oluştur, CreatedDate’i koru, ModifiedDate’i güncelle, durumu güncelle
            CustomerDto dto = new()
            {
                Id = pageVm.Request.Id,
                BrideName = pageVm.Request.BrideName,
                GroomName = pageVm.Request.GroomName,
                LastName = pageVm.Request.LastName,
                Phone1 = pageVm.Request.Phone1,
                Phone2 = pageVm.Request.Phone2,
                Email = pageVm.Request.Email,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _customerManager.UpdateAsync(dto); // BLL ile güncelle

                TempData["SuccessMessage"] = "Müşteri başarıyla güncellendi."; // Başarı mesajı
                return RedirectToAction(nameof(Index)); // Listeye dön
            }
            catch (Exception ex)
            {
                pageVm.Response.IsSuccess = false;       // Hata durumu
                pageVm.Response.ErrorMessage = ex.Message;  // Hata mesajı
                return View(pageVm);                       // Formu hata ile tekrar göster
            }
        }

        #endregion

        #region CustomerDeleteAction

        /// <summary>
        /// Silme onay sayfasını görüntüler.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            // BLL'den kaydı al
            CustomerDto dto = await _customerManager.GetByIdAsync(id);
            // Yoksa veya zaten silinmişse 404
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound();

            // Onay VM'i hazırla
            CustomerDeletePageVm pageVm = new()
            {
                Request = new CustomerDeleteRequestModel
                {
                    Id = dto.Id,
                    FullName = $"{dto.BrideName} {dto.GroomName} {dto.LastName}"
                }
            };
            return View(pageVm); // Delete.cshtml'i göster
        }

        /// <summary>
        /// Soft-delete: kaydı “silinmiş” olarak işaretler.
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CustomerDeletePageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm); // Validasyon hatalıysa tekrar göster

            // Kaydı al ve durumu kontrol et
            CustomerDto dto = await _customerManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted) return NotFound();

            // Soft-delete: BLL katmanındaki MakePassiveAsync’i kullan
            await _customerManager.MakePassiveAsync(new CustomerDto { Id = pageVm.Request.Id });

            TempData["SuccessMessage"] = "Müşteri başarıyla silindi.";
            return RedirectToAction(nameof(Index)); // Listeye dönüş
        }

        #endregion
    }
}
