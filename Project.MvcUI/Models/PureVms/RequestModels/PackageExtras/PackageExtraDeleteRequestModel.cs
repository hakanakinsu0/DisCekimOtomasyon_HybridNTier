using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.PackageExtras
{
    /// <summary>
    /// Silinecek paket-ekstra kaydının Id ve açıklamasını tutar.
    /// </summary>
    public class PackageExtraDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }                     // Silinecek kaydın Id’si

        public string Description { get; set; } = "";   // Onay ekranında gösterilecek bilgi
    }
}
