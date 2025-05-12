namespace Project.MvcUI.Models.PureVms.ResponseModels.Customers
{
    /// <summary>
    /// Yeni müşteri ekleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class CustomerCreateResponseModel
    {
        // İşlemin başarı durumu
        public bool IsSuccess { get; set; }
        // Başarısızsa gösterilecek hata mesajı
        public string? ErrorMessage { get; set; }
    }
}
