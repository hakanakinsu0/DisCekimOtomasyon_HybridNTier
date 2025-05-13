using Project.MvcUI.Models.PureVms.RequestModels.Reservations;
using Project.MvcUI.Models.PureVms.ResponseModels.Reservations;

namespace Project.MvcUI.Models.PageVms.Reservations
{
    /// <summary>
    /// Rezervasyon silme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ReservationDeletePageVm
    {
        public ReservationDeleteRequestModel Request { get; set; } = new ReservationDeleteRequestModel();
        public ReservationDeleteResponseModel Response { get; set; } = new ReservationDeleteResponseModel();
    }
}
