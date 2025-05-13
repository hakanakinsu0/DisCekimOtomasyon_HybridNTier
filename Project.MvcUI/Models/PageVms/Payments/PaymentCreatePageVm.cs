using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.Payments;
using Project.MvcUI.Models.PureVms.ResponseModels.Payments;

namespace Project.MvcUI.Models.PageVms.Payments
{
    /// <summary>
    /// Ödeme ekleme sayfası için istek/yanıt modelleri ve rezervasyon dropdown’unu içerir.
    /// </summary>
    public class PaymentCreatePageVm
    {
        // Formdan gelen verileri tutar
        public PaymentCreateRequestModel Request { get; set; } = new PaymentCreateRequestModel();

        // İşlem sonucunu ve hata mesajını tutar
        public PaymentCreateResponseModel Response { get; set; } = new PaymentCreateResponseModel();

        // Rezervasyonları dropdown olarak göstermek için
        public List<SelectListItem> Reservations { get; set; } = new();
    }
}
