using Project.MvcUI.Models.PureVms.RequestModels.Payments;
using Project.MvcUI.Models.PureVms.ResponseModels.Payments;

namespace Project.MvcUI.Models.PageVms.Payments
{
    /// <summary>
    /// Ödeme listeleme sayfası için ViewModel; istek ve yanıt modellerini taşır.
    /// </summary>
    public class PaymentIndexPageVm
    {
        public PaymentIndexRequestModel Request { get; set; } = new PaymentIndexRequestModel();
        public PaymentIndexResponseModel Response { get; set; } = new PaymentIndexResponseModel();

        public Dictionary<int, string> CustomerNames { get; set; } = new();

    }
}
