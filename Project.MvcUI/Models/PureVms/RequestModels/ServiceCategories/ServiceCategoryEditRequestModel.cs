using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ServiceCategories
{
    /// <summary>
    /// Mevcut servis kategorisi düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class ServiceCategoryEditRequestModel
    {
        [Required]
        [Display(Name = "Kategori ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Albüm Firması")]
        public int AlbumCompanyId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
    }
}
