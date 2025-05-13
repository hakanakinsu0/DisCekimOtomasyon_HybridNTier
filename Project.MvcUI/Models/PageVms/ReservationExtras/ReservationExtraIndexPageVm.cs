using Project.MvcUI.Models.PureVms.RequestModels.ReservationExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.ReservationExtras;

namespace Project.MvcUI.Models.PageVms.ReservationExtras
{
    /// <summary>
    /// Rezervasyona ait ekstra hizmetlerin listelenmesi için PageVm.
    /// </summary>
    public class ReservationExtraIndexPageVm
    {
        public ReservationExtraIndexRequestModel Request { get; set; } = new ReservationExtraIndexRequestModel();
        public ReservationExtraIndexResponseModel Response { get; set; } = new ReservationExtraIndexResponseModel();
    }
}
