using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.SizeOptions
{
    /// <summary>
    /// Yeni ölçü seçeneği ekleme formundan gelen verileri tutar.
    /// </summary>
    public class SizeOptionCreateRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Kategori")]
        public int ServiceCategoryId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Ölçü (Dimension)")]
        public string Dimension { get; set; }
    }
}
