using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ExtraServices
{
    /// <summary>
    /// Mevcut ekstra hizmet düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class ExtraServiceEditRequestModel
    {
        [Required]
        [Display(Name = "Hizmet ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Kategori")]
        public int ExtraServiceCategoryId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Hizmet Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} negatif olamaz.")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
    }
}
