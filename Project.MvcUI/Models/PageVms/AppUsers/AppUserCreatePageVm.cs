using Project.MvcUI.Models.PureVms.RequestModels.AppUsers;
using Project.MvcUI.Models.PureVms.ResponseModels.AppUsers;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Kullanıcı oluşturma sayfası için istek/yanıt modellerini içerir.
    /// </summary>
    public class AppUserCreatePageVm
    {
        public AppUserCreateRequestModel Request { get; set; } = new();
        public AppUserCreateResponseModel Response { get; set; } = new();
    }
}
