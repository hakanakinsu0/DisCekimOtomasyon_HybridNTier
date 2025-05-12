using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.Locations
{
    /// <summary>
    /// Mevcut bir mekanın düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class LocationEditRequestModel
    {
        [Required]
        [Display(Name = "Mekan ID")]
        public int Id { get; set; }                    // Düzenlenecek mekanın kimliği

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Mekan Adı")]
        public string Name { get; set; }               // Mekan adı

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }            // Adres bilgisi

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "İlçe")]
        public string District { get; set; }           // İlçe adı

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Şehir")]
        public string City { get; set; }               // Şehir adı

        [Phone(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }             // Telefon numarası (opsiyonel)

        [Display(Name = "Ücretsiz")]
        public bool IsFree { get; set; }               // Ücretsiz mi?

        [Range(0, double.MaxValue, ErrorMessage = "{0} negatif olamaz.")]
        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }            // Ücret bilgisi (opsiyonel)
    }
}
