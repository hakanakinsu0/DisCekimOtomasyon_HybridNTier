using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.PackageOptions
{
    /// <summary>
    /// Mevcut paket seçeneği düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class PackageOptionEditRequestModel
    {
        [Required]
        [Display(Name = "Paket ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Paket Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} negatif olamaz.")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
    }
}
