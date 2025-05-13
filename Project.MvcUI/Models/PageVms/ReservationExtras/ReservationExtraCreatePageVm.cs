using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.ReservationExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.ReservationExtras;

namespace Project.MvcUI.Models.PageVms.ReservationExtras
{
    /// <summary>
    /// Rezervasyona ekstra hizmet ekleme sayfası için istek/yanıt modelleri ve dropdown verilerini içerir.
    /// </summary>
    public class ReservationExtraCreatePageVm
    {
        // Formdan gelen verileri tutar
        public ReservationExtraCreateRequestModel Request { get; set; } = new ReservationExtraCreateRequestModel();

        // İşlem sonucunu tutar
        public ReservationExtraCreateResponseModel Response { get; set; } = new ReservationExtraCreateResponseModel();

        // Rezervasyon ve ekstra hizmet listeleri dropdown için
        public List<SelectListItem> Reservations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ExtraServices { get; set; } = new List<SelectListItem>();
    }
}
