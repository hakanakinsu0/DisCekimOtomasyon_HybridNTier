using Project.MvcUI.Models.PureVms.RequestModels.Locations;
using Project.MvcUI.Models.PureVms.ResponseModels.Locations;

namespace Project.MvcUI.Models.PageVms.Locations
{
    /// <summary>
    /// Mekan silme sayfası için istek ve yanıt modellerini kapsayan view model.
    /// </summary>
    public class LocationDeletePageVm
    {
        // Silinecek mekanın bilgilerini içerir
        public LocationDeleteRequestModel Request { get; set; } = new LocationDeleteRequestModel();

        // Silme sonucunu ve mesajı içerir
        public LocationDeleteResponseModel Response { get; set; } = new LocationDeleteResponseModel();
    }
}
