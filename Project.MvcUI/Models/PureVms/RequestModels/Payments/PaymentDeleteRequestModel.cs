using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.Payments
{
    /// <summary>
    /// Silinecek ödemenin Id ve açıklamasını tutar.
    /// </summary>
    public class PaymentDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }                   // Silinecek ödemenin Id’si

        public string Description { get; set; } = ""; // Onay ekranında gösterilecek bilgi
    }
}
