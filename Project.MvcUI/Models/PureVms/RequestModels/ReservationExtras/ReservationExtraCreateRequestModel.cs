using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ReservationExtras
{
    /// <summary>
    /// Rezervasyona ekstra hizmet ekleme formundan gelen verileri tutar.
    /// </summary>
    public class ReservationExtraCreateRequestModel
    {
        // route’dan gelen rezervasyon ID
        public int ReservationId { get; set; }

        // paket opsiyon ID (isteğe bağlı: görünümde hidden olarak da tutabilirsiniz)
        public int PackageOptionId { get; set; }

        // birden fazla ekstra hizmet seçilecekse bu listeyi kullanacağız
        public List<int> SelectedExtraIds { get; set; } = new List<int>();
    }
}
