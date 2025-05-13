using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.PackageOptions
{
    /// <summary>
    /// Yeni paket seçeneği ekleme formundan gelen verileri tutar.
    /// </summary>
    public class PackageOptionCreateRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Paket Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} negatif olamaz.")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
    }
}
