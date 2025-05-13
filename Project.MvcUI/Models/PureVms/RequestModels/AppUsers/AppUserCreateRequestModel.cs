using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.AppUsers
{
    /// <summary>
    /// Yeni kullanıcı ekleme formundan gelen verileri tutar.
    /// </summary>
    public class AppUserCreateRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        [Display(Name = "Şifre (Tekrar)")]
        public string ConfirmPassword { get; set; }
    }
}
