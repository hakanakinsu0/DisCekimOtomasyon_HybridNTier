using Project.MvcUI.Models.PureVms.RequestModels.Payments;
using Project.MvcUI.Models.PureVms.ResponseModels.Payments;

namespace Project.MvcUI.Models.PageVms.Payments
{
    /// <summary>
    /// Ödeme silme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class PaymentDeletePageVm
    {
        public PaymentDeleteRequestModel Request { get; set; } = new PaymentDeleteRequestModel();
        public PaymentDeleteResponseModel Response { get; set; } = new PaymentDeleteResponseModel();
    }
}
