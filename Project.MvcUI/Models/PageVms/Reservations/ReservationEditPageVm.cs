using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.Reservations;
using Project.MvcUI.Models.PureVms.ResponseModels.Reservations;

namespace Project.MvcUI.Models.PageVms.Reservations
{
    /// <summary>
    /// Rezervasyon düzenleme sayfası için istek/yanıt modellerini ve dropdown listelerini içerir.
    /// </summary>
    public class ReservationEditPageVm
    {
        public ReservationEditRequestModel Request { get; set; } = new ReservationEditRequestModel();
        public ReservationEditResponseModel Response { get; set; } = new ReservationEditResponseModel();

        public List<SelectListItem> Customers { get; set; } = new();
        public List<SelectListItem> Locations { get; set; } = new();
        public List<SelectListItem> Photographers { get; set; } = new();
        public List<SelectListItem> ServiceCategories { get; set; } = new();
        public List<SelectListItem> PackageOptions { get; set; } = new();
        public List<SelectListItem> AppUsers { get; set; } = new();
    }
}
