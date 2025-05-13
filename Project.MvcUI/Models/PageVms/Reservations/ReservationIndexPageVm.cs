using Project.MvcUI.Models.PureVms.RequestModels.Reservations;
using Project.MvcUI.Models.PureVms.ResponseModels.Reservations;

namespace Project.MvcUI.Models.PageVms.Reservations
{
    /// <summary>
    /// Rezervasyon listeleme sayfası için ViewModel; istek ve yanıt modellerini taşır.
    /// </summary>
    public class ReservationIndexPageVm
    {
        public ReservationIndexRequestModel Request { get; set; } = new ReservationIndexRequestModel();
        public ReservationIndexResponseModel Response { get; set; } = new ReservationIndexResponseModel();
    }
}
