using Microsoft.AspNetCore.Identity;
using Project.BLL.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface IAppUserManager : IManager<AppUserDto, AppUser>
    {
        /// <summary>
        /// Kullanıcı adı ve şifre ile oturum açmayı dener.
        /// </summary>
        /// <returns>
        /// Succeeded: Başarılı mı?
        /// ErrorMessage: Başarısızsa kullanıcıya gösterilecek mesaj.
        /// </returns>
        Task<(bool Succeeded, string? ErrorMessage)> LoginAsync(string username, string password, bool rememberMe);

        /// <summary>
        /// Mevcut oturumu sonlandırır.
        /// </summary>
        Task LogoutAsync();

        /// <summary>
        /// Yeni kullanıcı için benzersiz bir aktivasyon kodu üretir.
        /// </summary>
        Guid GenerateActivationCode();

        /// <summary>
        /// Yeni bir AppUser kaydı oluşturur.
        /// </summary>
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);

        /// <summary>
        /// Oluşturulan kullanıcıya belirtilen rolü atar.
        /// </summary>
        Task<IdentityResult> AssignRoleAsync(AppUser user, string role);

        /// <summary>
        /// Kayıt sırasında kullanıcıya aktivasyon e-postası gönderir.
        /// </summary>
        Task SendActivationEmailAsync(AppUser user, Guid activationCode);

        /// <summary>
        /// Gelen aktivasyon kodunu ve kullanıcı ID’sini kontrol ederek e-posta onayını gerçekleştirir.
        /// </summary>
        Task<IdentityResult> ConfirmEmailAsync(int userId, Guid activationCode);

        /// <summary>
        /// E-posta adresine göre kullanıcı bilgisini getirir.
        /// </summary>
        Task<AppUserDto?> FindByEmailAsync(string email);

        /// <summary>
        /// Kullanıcı adına göre kullanıcı bilgisini getirir.
        /// </summary>
        Task<AppUserDto?> FindByUsernameAsync(string username);


    }
}
