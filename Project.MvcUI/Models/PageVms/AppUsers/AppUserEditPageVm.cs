using Project.MvcUI.Models.PureVms.RequestModels.AppUsers;
using Project.MvcUI.Models.PureVms.ResponseModels.AppUsers;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Kullanıcı düzenleme sayfası için ViewModel.
    /// </summary>
    public class AppUserEditPageVm
    {
        public AppUserEditRequestModel Request { get; set; } = new();
        public AppUserEditResponseModel Response { get; set; } = new();
    }
}
