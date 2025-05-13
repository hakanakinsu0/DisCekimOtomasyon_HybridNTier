namespace Project.MvcUI.Models.PureVms.ResponseModels.Payments
{
    /// <summary>
    /// Ödeme silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class PaymentDeleteResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
