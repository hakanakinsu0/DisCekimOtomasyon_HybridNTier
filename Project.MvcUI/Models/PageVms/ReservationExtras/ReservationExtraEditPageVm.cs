using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.ReservationExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.ReservationExtras;

namespace Project.MvcUI.Models.PageVms.ReservationExtras
{
    /// <summary>
    /// Rezervasyona ait ekstra hizmet düzenleme sayfası için istek/yanıt modelleri ve dropdown verilerini içerir.
    /// </summary>
    public class ReservationExtraEditPageVm
    {
        public ReservationExtraEditRequestModel Request { get; set; } = new ReservationExtraEditRequestModel();
        public ReservationExtraEditResponseModel Response { get; set; } = new ReservationExtraEditResponseModel();
        public List<SelectListItem> Reservations { get; set; } = new();
        public List<SelectListItem> ExtraServices { get; set; } = new();
    }
}
