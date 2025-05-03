using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.Common.Tools;
using Project.DAL.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class AppUserManager : BaseManager<AppUserDto, AppUser>, IAppUserManager
    {
        readonly SignInManager<AppUser> _signInManager;
        readonly UserManager<AppUser> _userManager;


        public AppUserManager(IAppUserRepository repository, IMapper mapper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : base(repository, mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Kullanıcının kullanıcı adı ve şifre bilgileriyle sisteme giriş yapmasını dener.
        /// </summary>
        /// <param name="username">Giriş için kullanılacak kullanıcı adı.</param>
        /// <param name="password">Kullanıcının şifresi.</param>
        /// <param name="rememberMe">
        /// Tarayıcı kapatıldıktan sonra oturumun devam edip etmeyeceğini belirten işaret.
        /// </param>
        /// <returns>
        /// İşlemin başarılı olup olmadığını gösteren <c>Succeeded</c> ve
        /// başarısızsa kullanıcıya gösterilecek <c>ErrorMessage</c> içeren tuple.
        /// </returns>
        public async Task<(bool Succeeded, string? ErrorMessage)> LoginAsync(string username, string password, bool rememberMe)
        {
            SignInResult? result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);

            return (result.Succeeded, result.Succeeded ? null : "Kullanıcı adı veya şifre hatalı.");
        }

        /// <summary>
        /// Mevcut kullanıcı oturumunu sonlandırır.
        /// </summary>
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        /// <summary>
        /// Yeni kullanıcı için benzersiz bir aktivasyon kodu üretir.
        /// </summary>
        public Guid GenerateActivationCode() => Guid.NewGuid();

        /// <summary>
        /// Yeni bir AppUser kaydı oluşturur.
        /// </summary>
        public Task<IdentityResult> CreateUserAsync(AppUser user, string password)
            => _userManager.CreateAsync(user, password);

        /// <summary>
        /// Oluşturulan kullanıcıya belirtilen rolü atar.
        /// </summary>
        public Task<IdentityResult> AssignRoleAsync(AppUser user, string role)
            => _userManager.AddToRoleAsync(user, role);

        /// <summary>
        /// Kayıt sırasında kullanıcıya aktivasyon e-postası gönderir.
        /// </summary>
        public async Task SendActivationEmailAsync(AppUser user, Guid activationCode)
        {
            string callback = $"http://localhost:5272/Account/ConfirmEmail?userId={user.Id}&activationCode={activationCode}";

            string body = $"<p>Hesabını oluşturuldu. <br><br>Hesabınızı onaylamak için " +
                          $"<a href=\"{callback}\">buraya tıklayın</a>.</p>";
            await MailService.SendAsync(user.Email, body: body, subject: "Hesap Onayı");
        }

        /// <summary>
        /// Gelen aktivasyon kodunu ve kullanıcı ID’sini kontrol ederek e-posta onayını gerçekleştirir.
        /// </summary>
        public async Task<IdentityResult> ConfirmEmailAsync(int userId, Guid activationCode)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null || user.ActivationCode != activationCode)
                return IdentityResult.Failed(
                    new IdentityError { Description = "Geçersiz kullanıcı veya kod." });

            user.EmailConfirmed = true;
            return await _userManager.UpdateAsync(user);
        }

        /// <summary>
        /// E-posta adresine göre kullanıcı bilgilerini getirir.
        /// </summary>
        public async Task<AppUserDto?> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null ? null : _mapper.Map<AppUserDto>(user);
        }

        /// <summary>
        /// Kullanıcı adına göre kullanıcı bilgilerini getirir.
        /// </summary>
        public async Task<AppUserDto?> FindByUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user == null ? null : _mapper.Map<AppUserDto>(user);
        }
    }
}
