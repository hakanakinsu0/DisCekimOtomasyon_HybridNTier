using Project.MvcUI.Models.PureVms.RequestModels.Locations;
using Project.MvcUI.Models.PureVms.ResponseModels.Locations;

namespace Project.MvcUI.Models.PageVms.Locations
{
    /// <summary>
    /// Mekan düzenleme sayfası için istek ve yanıt modellerini kapsayan view model.
    /// </summary>
    public class LocationEditPageVm
    {
        // Formdan gelen düzenleme verilerini içerir
        public LocationEditRequestModel Request { get; set; } = new LocationEditRequestModel();

        // Düzenleme sonucunu ve hata mesajını içerir
        public LocationEditResponseModel Response { get; set; } = new LocationEditResponseModel();
    }
}
