using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ServiceCategories
{
    /// <summary>
    /// Yeni servis kategorisi ekleme formundan gelen verileri tutar.
    /// </summary>
    public class ServiceCategoryCreateRequestModel
    {
        [Required]
        [Display(Name = "Albüm Firması")]
        public int AlbumCompanyId { get; set; }      // Yeni eklendi

        [Required]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
    }
}
