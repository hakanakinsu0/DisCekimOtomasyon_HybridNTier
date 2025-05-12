namespace Project.MvcUI.Models.PureVms.RequestModels.Customers
{
    /// <summary>
    /// Silme onayı için gerekli müşteri Id ve görüntülenecek ad-soyad bilgisini tutar.
    /// </summary>
    public class CustomerDeleteRequestModel
    {
        // Silinecek kaydın Id’si
        public int Id { get; set; }

        // Onay sayfasında gösterilecek ad-soyad bilgisi
        public string FullName { get; set; } = string.Empty;
    }
}
