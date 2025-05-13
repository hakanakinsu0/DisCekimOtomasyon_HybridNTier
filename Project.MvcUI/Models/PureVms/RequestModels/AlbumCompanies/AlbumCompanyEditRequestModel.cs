using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.AlbumCompanies
{
    /// <summary>
    /// Mevcut albüm firması düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class AlbumCompanyEditRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Firma Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Phone(ErrorMessage = "{0} geçerli bir telefon değil.")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "{0} geçerli bir e-posta değil.")]
        [Display(Name = "E-posta")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Yetkili Adı")]
        public string ContactPersonName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Phone(ErrorMessage = "{0} geçerli bir telefon değil.")]
        [Display(Name = "Yetkili Telefon")]
        public string ContactPersonPhone { get; set; }

        [EmailAddress(ErrorMessage = "{0} geçerli bir e-posta değil.")]
        [Display(Name = "Yetkili E-posta")]
        public string? ContactPersonEmail { get; set; }
    }
}
