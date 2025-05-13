using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.AppUsers
{
    /// <summary>
    /// Mevcut kullanıcı düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class AppUserEditRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
    }
}
