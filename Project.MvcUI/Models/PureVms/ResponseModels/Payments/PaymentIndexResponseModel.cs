using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.Payments
{
    /// <summary>
    /// Ödeme listesini içeren yanıt modelidir.
    /// </summary>
    public class PaymentIndexResponseModel
    {
        public List<PaymentDto> Payments { get; set; } = new();  // PaymentDto: ReservationId, TotalAmount, PaidAmount, RemainingAmount, LastPaymentDate :contentReference[oaicite:0]{index=0}:contentReference[oaicite:1]{index=1}
    }
}
