using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PageVms.Accounts;
using Project.MvcUI.Models.PureVms.RequestModels.Accounts;
using Project.MvcUI.Models.PureVms.ResponseModel.Accounts;

namespace Project.MvcUI.Controllers
{
    public class AccountController : Controller
    {
        readonly IAppUserManager _appUserManager;

        public AccountController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        #region LoginAccount

        public IActionResult Login(string returnUrl = null)
        {
            LoginPageVm pageVm = new()
            {
                Request = new LoginRequestModel { ReturnUrl = returnUrl }, // ReturnUrl parametresi ayarlanır
                Response = new LoginResponseModel()                           // Boş bir ResponseModel oluşturulur
            };

            return View(pageVm); // Login view'ı pageVm ile render edilir
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginPageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm); // Model doğrulaması başarısızsa aynı view'ı validasyon hatalarıyla yeniden göster

            var (succeeded, errorMessage) = await _appUserManager.LoginAsync(pageVm.Request.Username,   pageVm.Request.Password, pageVm.Request.RememberMe); // Kullanıcı adı ile giriş yapılır,Şifre doğrulaması yapılır, "Beni hatırla" seçeneği işlenir.

            if (succeeded) // Giriş başarılıysa
            {
                TempData["SuccessMessage"] = "Giriş işlemi başarıyla gerçekleşti."; // Başarı mesajı ayarlanır
                return Redirect(pageVm.Request.ReturnUrl ?? "/Home/Index");        // ReturnUrl veya ana sayfaya yönlendirilir
            }

            pageVm.Response = new LoginResponseModel // Giriş başarısızsa response modeli güncellenir
            {
                IsSuccess = false,    // İşlem sonucu
                ErrorMessage = errorMessage // Hata mesajı
            };

            ModelState.AddModelError(string.Empty, errorMessage); // ModelState'e genel hata eklenir
            return View(pageVm); // Hata mesajı ile view yeniden gösterilir
        }

        #endregion

        #region LogoutAccount

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _appUserManager.LogoutAsync(); // Oturumu sonlandırır
            TempData["SuccessMessage"] = "Oturumunuz başarıyla kapatıldı."; // Başarı mesajı ayarlanır
            return RedirectToAction("Login", "Account"); // Login sayfasına yönlendirilir
        }
        #endregion

        #region RegisterAccount

        [Authorize(Roles = "Admin")]                      // Sadece Admin görebilsin
        public IActionResult Register()
        {
            RegisterPageVm pageVm = new()
            {
                Request = new RegisterRequestModel(),
                Response = new RegisterResponseModel()
            };

            return View(pageVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]                      // Sadece Admin çalıştırabilsin
        public async Task<IActionResult> Register(RegisterPageVm pageVm)
        {
            if (!ModelState.IsValid) return View(pageVm); // Model validasyonu

            // E-posta veya kullanıcı adı kontrolü
            AppUserDto? existsByEmail = await _appUserManager.FindByEmailAsync(pageVm.Request.Email);
            AppUserDto? existsByUsername = await _appUserManager.FindByUsernameAsync(pageVm.Request.Username);

            if (existsByEmail != null || existsByUsername != null)
            {
                ModelState.AddModelError(string.Empty, "Bu e-posta veya kullanıcı adı zaten kullanımda.");
                return View(pageVm);
            }

            // Aktivasyon kodu üretme
            Guid activationCode = _appUserManager.GenerateActivationCode();

            // Yeni kullanıcı nesnesi oluşturma
            AppUser user = new()
            {
                UserName = pageVm.Request.Username,
                Email = pageVm.Request.Email,
                ActivationCode = activationCode,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // Kullanıcı oluşturma
            IdentityResult createResult = await _appUserManager.CreateUserAsync(user, pageVm.Request.Password);

            if (!createResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kayıt sırasında bir hata oluştu.");
                return View(pageVm);
            }

            // Admin rolünü ata
            await _appUserManager.AssignRoleAsync(user, "Admin");

            // Aktivasyon e-postası gönder
            await _appUserManager.SendActivationEmailAsync(user, activationCode);

            // Onay bekleme paneline yönlendir
            return RedirectToAction("RedirectPanel");
        }

        #endregion

        #region RedirectPanel

        /// <summary>
        /// Kayıt sonrası e-posta onayı bekleme sayfasını döndürür.
        /// </summary>

        [Authorize(Roles = "Admin")]                      // Sadece Admin görebilsin
        public IActionResult RedirectPanel()
        {
            return View();
        }

        #endregion

        #region ConfirmEmail

        /// <summary>
        /// Gelen activationCode ve userId ile e-posta onayını yapar,
        /// ardından doğrudan Login sayfasına yönlendirir.
        /// </summary>
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(int userId, Guid activationCode)
        {
            IdentityResult result = await _appUserManager.ConfirmEmailAsync(userId, activationCode);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Hesabınız başarıyla onaylandı. Giriş yapabilirsiniz.";
            }
            else
            {
                TempData["ErrorMessage"] = "E-posta onayı başarısız oldu. Lütfen bilgilerinizi kontrol edin.";
            }

            return RedirectToAction("Login", new { returnUrl = (string?)null });
        }

        #endregion
    }
}

