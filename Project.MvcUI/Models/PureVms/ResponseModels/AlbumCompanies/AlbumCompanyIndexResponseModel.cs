using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.AlbumCompanies
{
    /// <summary>
    /// Albüm firması listesi ve durum bilgisini tutar.
    /// </summary>
    public class AlbumCompanyIndexResponseModel
    {
        public List<AlbumCompanyDto> AlbumCompanies { get; set; } = new();
    }
}
