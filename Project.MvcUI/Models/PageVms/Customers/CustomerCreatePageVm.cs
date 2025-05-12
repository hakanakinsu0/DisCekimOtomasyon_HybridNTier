using Project.MvcUI.Models.PureVms.RequestModels.Customers;
using Project.MvcUI.Models.PureVms.ResponseModels.Customers;

namespace Project.MvcUI.Models.PageVms.Customers
{
    /// <summary>
    /// Customer Create sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class CustomerCreatePageVm
    {
        // Formdan gelen yeni müşteri bilgilerini tutar.
        public CustomerCreateRequestModel Request { get; set; } = new CustomerCreateRequestModel();

        // Ekleme işleminin sonucuna dair başarı durumu ve hata mesajını içerir.
        public CustomerCreateResponseModel Response { get; set; } = new CustomerCreateResponseModel();
    }
}
