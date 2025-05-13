using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.Reservations
{
    /// <summary>
    /// Silinecek rezervasyonun Id ve açıklamasını tutar.
    /// </summary>
    public class ReservationDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }                    // Silinecek rezervasyonun Id’si

        public string Description { get; set; } = "";  // Onay ekranında gösterilecek bilgi
    }
}
