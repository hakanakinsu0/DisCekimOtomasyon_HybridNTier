using Project.MvcUI.Models.PureVms.RequestModels.AlbumCompanies;
using Project.MvcUI.Models.PureVms.ResponseModels.AlbumCompanies;

namespace Project.MvcUI.Models.PageVms.AlbumCompanies
{
    /// <summary>
    /// Albüm firması silme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class AlbumCompanyDeletePageVm
    {
        public AlbumCompanyDeleteRequestModel Request { get; set; } = new AlbumCompanyDeleteRequestModel();
        public AlbumCompanyDeleteResponseModel Response { get; set; } = new AlbumCompanyDeleteResponseModel();
    }
}
