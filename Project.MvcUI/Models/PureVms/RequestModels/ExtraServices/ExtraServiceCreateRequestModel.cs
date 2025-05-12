using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ExtraServices
{
    /// <summary>
    /// Yeni ekstra hizmet ekleme formundan gelen verileri tutar.
    /// </summary>
    public class ExtraServiceCreateRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Kategori")]
        public int ExtraServiceCategoryId { get; set; }   // Yeni

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Hizmet Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} negatif olamaz.")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
    }
}
