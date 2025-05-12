using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.Locations
{
    /// <summary>
    /// Silme onayı için gerekli mekan Id ve görüntülenecek ad bilgisini tutar.
    /// </summary>
    public class LocationDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }                    // Silinecek mekanın kimliği

        public string Name { get; set; } = string.Empty;  // Onay sayfasında gösterilecek mekan adı
    }
}
