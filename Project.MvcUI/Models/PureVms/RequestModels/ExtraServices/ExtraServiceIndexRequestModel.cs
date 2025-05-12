using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ExtraServices
{
    /// <summary>
    /// Ekstra hizmet listesi sayfası için gelen arama terimini tutar.
    /// </summary>
    public class ExtraServiceIndexRequestModel
    {
        [Display(Name = "Ara")]
        public string? SearchTerm { get; set; }    // Ad veya fiyat üzerinden arama
    }
}
