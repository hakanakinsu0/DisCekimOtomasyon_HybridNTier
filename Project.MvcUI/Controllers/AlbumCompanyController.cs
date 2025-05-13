using Microsoft.AspNetCore.Mvc;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.MvcUI.Models.PageVms.AlbumCompanies;
using Project.MvcUI.Models.PureVms.RequestModels.AlbumCompanies;
using Project.MvcUI.Models.PureVms.ResponseModels.AlbumCompanies;

namespace Project.MvcUI.Controllers
{
    public class AlbumCompanyController : Controller
    {
        readonly IAlbumCompanyManager _albumCompanyManager;

        public AlbumCompanyController(IAlbumCompanyManager albumCompanyManager)
        {
            _albumCompanyManager = albumCompanyManager;
        }

        #region AlbumCompanyIndexAction

        /// <summary>
        /// Albüm firması listesini getirir; isteğe bağlı ad filtresi uygular.
        /// </summary>
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // BLL'de tanımlı filtreli veya tüm listeyi dönen metodu çağır
            var list = await _albumCompanyManager.GetAllWithFilterAsync(searchTerm);

            var pageVm = new AlbumCompanyIndexPageVm
            {
                Request = new AlbumCompanyIndexRequestModel { SearchTerm = searchTerm },
                Response = new AlbumCompanyIndexResponseModel { AlbumCompanies = list }
            };

            return View(pageVm);
        }

        #endregion

        #region AlbumCompanyCreateAction

        /// <summary>
        /// Yeni albüm firması ekleme formunu görüntüler.
        /// </summary>
        public IActionResult Create()
        {
            var pageVm = new AlbumCompanyCreatePageVm();
            return View(pageVm);
        }

        /// <summary>
        /// Formdan gelen bilgilerle yeni albüm firması oluşturur.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlbumCompanyCreatePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = new AlbumCompanyDto
            {
                Name = pageVm.Request.Name,
                Address = pageVm.Request.Address,
                Phone = pageVm.Request.Phone,
                Email = pageVm.Request.Email,
                ContactPersonName = pageVm.Request.ContactPersonName,
                ContactPersonPhone = pageVm.Request.ContactPersonPhone,
                ContactPersonEmail = pageVm.Request.ContactPersonEmail,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            try
            {
                await _albumCompanyManager.CreateAsync(dto); // Yeni kayıt
                TempData["SuccessMessage"] = "Albüm firması başarıyla eklendi.";
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

        #region AlbumCompanyEditAction

        /// <summary>
        /// Albüm firması düzenleme formunu görüntüler.
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _albumCompanyManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new AlbumCompanyEditPageVm
            {
                Request = new Models.PureVms.RequestModels.AlbumCompanies.AlbumCompanyEditRequestModel
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Address = dto.Address,
                    Phone = dto.Phone,
                    Email = dto.Email,
                    ContactPersonName = dto.ContactPersonName,
                    ContactPersonPhone = dto.ContactPersonPhone,
                    ContactPersonEmail = dto.ContactPersonEmail
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Düzenleme formundan gelen verilerle albüm firmasını günceller.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AlbumCompanyEditPageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var existing = await _albumCompanyManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null)
                return NotFound();

            var dto = new AlbumCompanyDto
            {
                Id = pageVm.Request.Id,
                Name = pageVm.Request.Name,
                Address = pageVm.Request.Address,
                Phone = pageVm.Request.Phone,
                Email = pageVm.Request.Email,
                ContactPersonName = pageVm.Request.ContactPersonName,
                ContactPersonPhone = pageVm.Request.ContactPersonPhone,
                ContactPersonEmail = pageVm.Request.ContactPersonEmail,
                CreatedDate = existing.CreatedDate,
                ModifiedDate = DateTime.Now,
                Status = DataStatus.Updated
            };

            try
            {
                await _albumCompanyManager.UpdateAsync(dto);
                TempData["SuccessMessage"] = "Albüm firması başarıyla güncellendi.";
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

        #region AlbumCompanyDeleteAction

        /// <summary>
        /// Albüm firması silme onay sayfasını gösterir.
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _albumCompanyManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new AlbumCompanyDeletePageVm
            {
                Request = new AlbumCompanyDeleteRequestModel
                {
                    Id = dto.Id,
                    Name = dto.Name
                }
            };
            return View(pageVm);
        }

        /// <summary>
        /// Albüm firmasını soft-delete ile silinmiş olarak işaretler.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AlbumCompanyDeletePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = await _albumCompanyManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            await _albumCompanyManager.MakePassiveAsync(new AlbumCompanyDto { Id = dto.Id });

            TempData["SuccessMessage"] = "Albüm firması başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
