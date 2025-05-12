using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ExtraServiceCategories
{
    /// <summary>
    /// Yeni ekstra hizmet kategorisi ekleme formundan gelen verileri tutar.
    /// </summary>
    public class ExtraServiceCategoryCreateRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
    }
}
