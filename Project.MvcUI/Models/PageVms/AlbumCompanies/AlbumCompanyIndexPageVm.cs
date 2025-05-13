using Project.MvcUI.Models.PureVms.RequestModels.AlbumCompanies;
using Project.MvcUI.Models.PureVms.ResponseModels.AlbumCompanies;

namespace Project.MvcUI.Models.PageVms.AlbumCompanies
{
    /// <summary>
    /// Albüm firması liste sayfası için ViewModel; hem istek hem yanıt modellerini taşır.
    /// </summary>
    public class AlbumCompanyIndexPageVm
    {
        public AlbumCompanyIndexRequestModel Request { get; set; }
            = new AlbumCompanyIndexRequestModel();

        public AlbumCompanyIndexResponseModel Response { get; set; }
            = new AlbumCompanyIndexResponseModel();
    }
}
