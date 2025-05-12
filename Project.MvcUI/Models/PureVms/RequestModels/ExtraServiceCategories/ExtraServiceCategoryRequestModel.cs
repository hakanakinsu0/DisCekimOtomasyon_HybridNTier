using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ExtraServiceCategories
{
    /// <summary>
    /// Mevcut ekstra hizmet kategorisi düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class ExtraServiceCategoryEditRequestModel
    {
        [Required]
        [Display(Name = "Kategori ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
    }
}
