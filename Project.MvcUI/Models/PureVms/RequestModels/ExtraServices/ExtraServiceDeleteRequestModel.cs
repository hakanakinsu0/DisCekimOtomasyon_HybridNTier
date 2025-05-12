using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ExtraServices
{
    /// <summary>
    /// Silinecek ekstra hizmet bilgilerini tutar.
    /// </summary>
    public class ExtraServiceDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }            // Silinecek hizmetin Id’si

        public string Name { get; set; } = ""; // Onay sayfasında gösterilecek hizmet adı
    }
}
