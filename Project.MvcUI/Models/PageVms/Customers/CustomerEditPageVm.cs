using Project.MvcUI.Models.PureVms.RequestModels.Customers;
using Project.MvcUI.Models.PureVms.ResponseModels.Customers;

namespace Project.MvcUI.Models.PageVms.Customers
{
    /// <summary>
    /// Müşteri düzenleme sayfası için istek ve yanıt modellerini kapsayan view model.
    /// </summary>
    public class CustomerEditPageVm
    {
        // Formdan gelen düzenleme verilerini içerir
        public CustomerEditRequestModel Request { get; set; } = new CustomerEditRequestModel();

        // Düzenleme sonucunu ve hata mesajını içerir
        public CustomerEditResponseModel Response { get; set; } = new CustomerEditResponseModel();
    }
}
