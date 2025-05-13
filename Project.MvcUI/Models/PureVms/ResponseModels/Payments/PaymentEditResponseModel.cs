namespace Project.MvcUI.Models.PureVms.ResponseModels.Payments
{
    /// <summary>
    /// Ödeme güncelleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class PaymentEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
