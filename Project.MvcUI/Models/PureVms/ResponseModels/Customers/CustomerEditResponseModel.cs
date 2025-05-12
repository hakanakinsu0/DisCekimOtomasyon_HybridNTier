namespace Project.MvcUI.Models.PureVms.ResponseModels.Customers
{
    /// <summary>
    /// Düzenleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class CustomerEditResponseModel
    {
        // İşlemin başarı durumu
        public bool IsSuccess { get; set; }

        // Başarısızsa gösterilecek hata mesajı
        public string? ErrorMessage { get; set; }
    }
}
