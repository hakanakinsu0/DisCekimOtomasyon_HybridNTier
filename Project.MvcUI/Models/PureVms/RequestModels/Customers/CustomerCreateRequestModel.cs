using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.Customers
{
    /// <summary>
    /// Yeni müşteri ekleme formundan gelen verileri tutar.
    /// </summary>
    public class CustomerCreateRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Gelin Adı")]
        public string BrideName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Damat Adı")]
        public string GroomName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "Telefon 1")]
        public string Phone1 { get; set; }

        [Phone(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "Telefon 2")]
        public string? Phone2 { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "E-posta")]
        public string? Email { get; set; }
    }
}
