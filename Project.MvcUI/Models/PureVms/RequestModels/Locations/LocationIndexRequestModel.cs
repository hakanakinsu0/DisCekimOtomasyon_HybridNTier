namespace Project.MvcUI.Models.PureVms.RequestModels.Locations
{
    /// <summary>
    /// Mekan listeleme sayfasından gönderilecek arama kriterini tutar.
    /// </summary>
    public class LocationIndexRequestModel
    {
        /// <summary>
        /// Mekan adı veya açıklaması üzerinden arama yapmak için kullanılacak terim.
        /// </summary>
        public string? SearchTerm { get; set; }
    }
}
