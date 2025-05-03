using Project.MvcUI.Models.PureVms.RequestModels.Accounts;
using Project.MvcUI.Models.PureVms.ResponseModel.Accounts;

namespace Project.MvcUI.Models.PageVms.Accounts
{
    public class LoginPageVm
    {
        // Binder, Request.* alanları formdan alıyor
        public LoginRequestModel Request { get; set; } = new LoginRequestModel();

        // Response formda gelmediği için null kalmasın diye örnek atıyoruz
        public LoginResponseModel Response { get; set; } = new LoginResponseModel();
    }
}
