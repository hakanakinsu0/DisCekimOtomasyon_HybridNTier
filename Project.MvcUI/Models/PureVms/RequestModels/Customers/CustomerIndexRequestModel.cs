namespace Project.MvcUI.Models.PureVms.RequestModels.Customers
{
    /// <summary>
    /// Müşteri listeleme sayfasından gönderilecek arama kriterlerini tutar.
    /// </summary>
    public class CustomerIndexRequestModel
    {
        /// <summary>
        /// Ad, soyad veya e-posta üzerinden arama yapmak için kullanılacak terim.
        /// </summary>
        public string? SearchTerm { get; set; }
    }
}
