using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.PackageOptions
{
    /// <summary>
    /// Paket seçenekleri listeleme sayfasından gelen arama terimini tutar.
    /// </summary>
    public class PackageOptionIndexRequestModel
    {
        [Display(Name = "Ara")]
        public string? SearchTerm { get; set; }
    }
}
