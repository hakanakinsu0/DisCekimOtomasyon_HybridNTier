using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PageVms.AppUsers;
using Project.MvcUI.Models.PureVms.RequestModels.AppUsers;
using Project.MvcUI.Models.PureVms.ResponseModels.AppUsers;

namespace Project.MvcUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AppUserController : Controller
    {
         readonly IAppUserManager _userManager;

        public AppUserController(IAppUserManager userManager)
        {
            _userManager = userManager;
        }

        #region AppUserIndexAction

        /// <summary>
        /// Tüm kullanıcıları listeler; isteğe bağlı kullanıcı adı veya e-posta ile arama yapar.
        /// </summary>
        public async Task<IActionResult> Index(string searchTerm = null)
        {
            // 1) BLL’den tüm kullanıcıları al
            var allUsers = await _userManager.GetAllAsync();

            // 2) Silinmiş (soft-delete) olanları çıkar
            var activeUsers = allUsers
                .Where(u => u.Status != DataStatus.Deleted)
                .ToList();

            // 3) Arama terimi varsa in-memory filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                activeUsers = activeUsers
                    .Where(u =>
                        u.UserName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        u.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // 4) PageVm’i oluştur
            var pageVm = new AppUserIndexPageVm
            {
                Request = new AppUserIndexRequestModel { SearchTerm = searchTerm },
                Response = new AppUserIndexResponseModel { Users = activeUsers }
            };

            return View(pageVm);
        }

        #endregion

        #region AppUserCreateAction

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var pageVm = new AppUserCreatePageVm();
            return View(pageVm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUserCreatePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            // Yeni kullanıcı nesnesi
            var user = new AppUser
            {
                UserName = pageVm.Request.Username,
                Email = pageVm.Request.Email,
                EmailConfirmed = false,
                ActivationCode = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // Şifre doğrulaması için base manager değil, AppUserManager metodunu kullanalım
            var result = await _userManager.CreateUserAsync(user, pageVm.Request.Password);
            if (!result.Succeeded)
            {
                pageVm.Response.IsSuccess = false;
                pageVm.Response.ErrorMessage = string.Join("; ", result.Errors.Select(e => e.Description));
                return View(pageVm);
            }

            // Oluşturulan kullanıcıya Admin rolü ata
            var roleResult = await _userManager.AssignRoleAsync(user, "Admin");
            if (!roleResult.Succeeded)
            {
                pageVm.Response.IsSuccess = false;
                pageVm.Response.ErrorMessage = string.Join("; ", roleResult.Errors.Select(e => e.Description));
                return View(pageVm);
            }

            TempData["SuccessMessage"] = "Kullanıcı başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region AppUserEditAction

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _userManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new AppUserEditPageVm
            {
                Request = new AppUserEditRequestModel
                {
                    Id = dto.Id,
                    Username = dto.UserName,
                    Email = dto.Email
                }
            };
            return View(pageVm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppUserEditPageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var existing = await _userManager.GetByIdAsync(pageVm.Request.Id);
            if (existing == null || existing.Status == DataStatus.Deleted)
                return NotFound();

            existing.UserName = pageVm.Request.Username;
            existing.Email = pageVm.Request.Email;
            existing.ModifiedDate = DateTime.Now;
            existing.Status = DataStatus.Updated;

            try
            {
                await _userManager.UpdateAsync(existing);
                TempData["SuccessMessage"] = "Kullanıcı başarıyla güncellendi.";
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

        #region AppUserDeleteAction

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _userManager.GetByIdAsync(id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            var pageVm = new AppUserDeletePageVm
            {
                Request = new AppUserDeleteRequestModel
                {
                    Id = dto.Id,
                    Username = dto.UserName
                }
            };
            return View(pageVm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AppUserDeletePageVm pageVm)
        {
            if (!ModelState.IsValid)
                return View(pageVm);

            var dto = await _userManager.GetByIdAsync(pageVm.Request.Id);
            if (dto == null || dto.Status == DataStatus.Deleted)
                return NotFound();

            // Soft-delete işlemi
            await _userManager.MakePassiveAsync(new AppUserDto { Id = dto.Id });

            TempData["SuccessMessage"] = "Kullanıcı başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        } 

        #endregion
    }
}
