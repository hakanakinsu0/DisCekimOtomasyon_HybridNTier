using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.PackageExtras
{
    /// <summary>
    /// Yeni paket-ekstra ilişkilendirme ekleme formundan gelen verileri tutar.
    /// </summary>
    public class PackageExtraCreateRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Paket Seçeneği")]
        public int PackageOptionId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Ekstra Hizmet")]
        public int ExtraServiceId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} en az {1} olabilir.")]
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
    }
}
