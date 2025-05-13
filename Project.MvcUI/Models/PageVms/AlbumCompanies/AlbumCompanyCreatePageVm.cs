using Project.MvcUI.Models.PureVms.RequestModels.AlbumCompanies;
using Project.MvcUI.Models.PureVms.ResponseModels.AlbumCompanies;

namespace Project.MvcUI.Models.PageVms.AlbumCompanies
{
    /// <summary>
    /// Albüm firması oluşturma sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class AlbumCompanyCreatePageVm
    {
        public AlbumCompanyCreateRequestModel Request { get; set; } = new AlbumCompanyCreateRequestModel();
        public AlbumCompanyCreateResponseModel Response { get; set; } = new AlbumCompanyCreateResponseModel();
    }
}
