using Project.MvcUI.Models.PureVms.RequestModels.Customers;
using Project.MvcUI.Models.PureVms.ResponseModels.Customers;

namespace Project.MvcUI.Models.PageVms.Customers
{
    /// <summary>
    /// Müşteri silme sayfası için istek ve yanıt modellerini kapsayan view model.
    /// </summary>
    public class CustomerDeletePageVm
    {
        // Silinecek müşterinin Id ve adı-soyadını tutar
        public CustomerDeleteRequestModel Request { get; set; } = new CustomerDeleteRequestModel();

        // Silme işlemi sonucunu ve hata mesajını içerir
        public CustomerDeleteResponseModel Response { get; set; } = new CustomerDeleteResponseModel();
    }
}
