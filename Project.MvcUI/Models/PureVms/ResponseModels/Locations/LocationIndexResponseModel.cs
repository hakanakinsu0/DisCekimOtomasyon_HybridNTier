using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.Locations
{
    /// <summary>
    /// Mekan listeleme sonucunda dönecek mekan DTO’larını içerir.
    /// </summary>
    public class LocationIndexResponseModel
    {
        /// <summary>
        /// Filtrelenmiş veya tüm mekan DTO listesini tutar.
        /// </summary>
        public List<LocationDto> Locations { get; set; } = new List<LocationDto>();
    }
}
