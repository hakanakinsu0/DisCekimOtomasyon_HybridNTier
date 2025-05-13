namespace Project.MvcUI.Models.PureVms.ResponseModels.Payments
{
    /// <summary>
    /// Ödeme ekleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class PaymentCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
