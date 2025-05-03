using Project.MvcUI.Models.PureVms.RequestModels.Accounts;
using Project.MvcUI.Models.PureVms.ResponseModel.Accounts;

namespace Project.MvcUI.Models.PageVms.Accounts
{
    public class RegisterPageVm
    {
        // Formdan gelecek verileri taşır; post sırasında zaten binder ile doldurulacak
        public RegisterRequestModel Request { get; set; } = new RegisterRequestModel();

        // Post sırasında gelmeyen bu property’yi default olarak örnekleyelim
        public RegisterResponseModel Response { get; set; } = new RegisterResponseModel();
    }
}
