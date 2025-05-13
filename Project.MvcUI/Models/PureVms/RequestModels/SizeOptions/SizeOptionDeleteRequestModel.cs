using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.SizeOptions
{
    /// <summary>
    /// Silinecek ölçü seçeneği bilgilerini tutar.
    /// </summary>
    public class SizeOptionDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }                // Silinecek kaydın Id’si

        public string Dimension { get; set; } = ""; // Onay ekranında gösterilecek ölçü değeri
    }
}
