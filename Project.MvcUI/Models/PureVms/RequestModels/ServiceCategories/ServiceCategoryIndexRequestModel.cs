using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ServiceCategories
{
    /// <summary>
    /// Servis kategorileri liste sayfası için gelen arama terimini tutar.
    /// </summary>
    public class ServiceCategoryIndexRequestModel
    {
        [Display(Name = "Ara")]
        public string? SearchTerm { get; set; }
    }
}
