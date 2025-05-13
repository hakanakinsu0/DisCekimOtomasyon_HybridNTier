using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.Reservations;
using Project.MvcUI.Models.PureVms.ResponseModels.Reservations;

namespace Project.MvcUI.Models.PageVms.Reservations
{
    /// <summary>
    /// Rezervasyon oluşturma sayfası için istek/yanıt modelleri ve dropdown listeleri içerir.
    /// </summary>
    public class ReservationCreatePageVm
    {
        public ReservationCreateRequestModel Request { get; set; } = new ReservationCreateRequestModel();
        public ReservationCreateResponseModel Response { get; set; } = new ReservationCreateResponseModel();

        // Dropdown kaynakları
        public List<SelectListItem> Customers { get; set; } = new();
        public List<SelectListItem> Locations { get; set; } = new();
        public List<SelectListItem> Photographers { get; set; } = new();
        public List<SelectListItem> ServiceCategories { get; set; } = new();
        public List<SelectListItem> PackageOptions { get; set; } = new();
        public List<SelectListItem> AppUsers { get; set; } = new();
    }
}
