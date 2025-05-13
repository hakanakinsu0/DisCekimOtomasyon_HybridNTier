using Project.MvcUI.Models.PureVms.RequestModels.ReservationExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.ReservationExtras;

namespace Project.MvcUI.Models.PageVms.ReservationExtras
{
    /// <summary>
    /// Rezervasyona ait ekstra hizmet silme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ReservationExtraDeletePageVm
    {
        public ReservationExtraDeleteRequestModel Request { get; set; } = new ReservationExtraDeleteRequestModel();
        public ReservationExtraDeleteResponseModel Response { get; set; } = new ReservationExtraDeleteResponseModel();
    }
}
