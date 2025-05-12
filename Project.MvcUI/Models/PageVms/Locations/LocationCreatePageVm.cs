using Project.MvcUI.Models.PureVms.RequestModels.Locations;
using Project.MvcUI.Models.PureVms.ResponseModels.Locations;

namespace Project.MvcUI.Models.PageVms.Locations
{
    /// <summary>
    /// Mekan ekleme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class LocationCreatePageVm
    {
        // Formdan gelen yeni mekan bilgilerini tutar.
        public LocationCreateRequestModel Request { get; set; } = new LocationCreateRequestModel();

        // Ekleme işlemi sonucunu ve mesajı içerir.
        public LocationCreateResponseModel Response { get; set; } = new LocationCreateResponseModel();
    }
}
