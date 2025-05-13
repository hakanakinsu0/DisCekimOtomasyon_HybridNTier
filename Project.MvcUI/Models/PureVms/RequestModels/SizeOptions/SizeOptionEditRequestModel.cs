using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.SizeOptions
{
    /// <summary>
    /// Mevcut ölçü seçeneği düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class SizeOptionEditRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Kategori")]
        public int ServiceCategoryId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Ölçü (Dimension)")]
        public string Dimension { get; set; }
    }
}
