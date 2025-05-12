using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.Locations
{
    // <summary>
    /// Yeni bir mekan ekleme formundan gelen verileri tutar.
    /// </summary>
    public class LocationCreateRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Mekan Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "İlçe")]
        public string District { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Şehir")]
        public string City { get; set; }

        [Phone(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Ücretsiz")]
        public bool IsFree { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "{0} negatif olamaz.")]
        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }
    }
}
