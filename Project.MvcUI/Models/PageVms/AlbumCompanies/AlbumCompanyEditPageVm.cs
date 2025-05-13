using Project.MvcUI.Models.PureVms.RequestModels.AlbumCompanies;
using Project.MvcUI.Models.PureVms.ResponseModels.AlbumCompanies;

namespace Project.MvcUI.Models.PageVms.AlbumCompanies
{
    /// <summary>
    /// Albüm firması düzenleme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class AlbumCompanyEditPageVm
    {
        public AlbumCompanyEditRequestModel Request { get; set; } = new AlbumCompanyEditRequestModel();
        public AlbumCompanyEditResponseModel Response { get; set; } = new AlbumCompanyEditResponseModel();
    }
}
