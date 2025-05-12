using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ExtraServiceCategories
{
    /// <summary>
    /// Ekstra hizmet kategorileri listesinden gelen arama terimini tutar.
    /// </summary>
    public class ExtraServiceCategoryIndexRequestModel
    {
        [Display(Name = "Ara")]
        public string? SearchTerm { get; set; }
    }
}
