namespace Project.MvcUI.Models.PureVms.ResponseModels.Customers
{
    /// <summary>
    /// Silme işleminin sonucunu (başarılı/başarısız) ve hata mesajını tutar.
    /// </summary>
    public class CustomerDeleteResponseModel
    {
        // İşlemin başarı durumu
        public bool IsSuccess { get; set; }
        // Başarısızsa gösterilecek hata mesajı
        public string? ErrorMessage { get; set; }
    }
}
