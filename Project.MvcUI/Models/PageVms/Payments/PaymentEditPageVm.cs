using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.Payments;
using Project.MvcUI.Models.PureVms.ResponseModels.Payments;

namespace Project.MvcUI.Models.PageVms.Payments
{
    /// <summary>
    /// Ödeme düzenleme sayfası için istek/yanıt modelleri ve rezervasyon dropdown’unu içerir.
    /// </summary>
    public class PaymentEditPageVm
    {
        // Form değerlerini tutar
        public PaymentEditRequestModel Request { get; set; } = new PaymentEditRequestModel();
        // İşlem sonucunu tutar
        public PaymentEditResponseModel Response { get; set; } = new PaymentEditResponseModel();
        // Rezervasyon listesini dropdown için taşır
        public List<SelectListItem> Reservations { get; set; } = new();
    }
}
