using Project.MvcUI.Models.PureVms.RequestModels.Locations;
using Project.MvcUI.Models.PureVms.ResponseModels.Locations;

namespace Project.MvcUI.Models.PageVms.Locations
{
    /// <summary>
    /// Mekan listeleme sayfası için istek ve yanıt modellerini kapsayan view model.
    /// </summary>
    public class LocationIndexPageVm
    {
        /// <summary>
        /// Sayfadan gelen arama kriterini tutar.
        /// </summary>
        public LocationIndexRequestModel Request { get; set; } = new LocationIndexRequestModel();

        /// <summary>
        /// BLL’den dönen mekan listesini içerir.
        /// </summary>
        public LocationIndexResponseModel Response { get; set; } = new LocationIndexResponseModel();
    }
}
