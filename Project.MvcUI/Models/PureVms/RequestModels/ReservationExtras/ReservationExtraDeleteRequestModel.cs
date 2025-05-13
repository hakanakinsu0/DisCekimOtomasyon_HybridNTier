using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ReservationExtras
{
    /// <summary>
    /// Silinecek rezervasyona ait ekstra hizmet kaydının Id bilgisini tutar.
    /// </summary>
    public class ReservationExtraDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }  // Silinecek kaydın Id’si

        public string Description { get; set; } = ""; // Onay ekranında gösterilecek bilgi
    }
}
