using Project.MvcUI.Models.PureVms.RequestModels.Customers;
using Project.MvcUI.Models.PureVms.ResponseModels.Customers;

namespace Project.MvcUI.Models.PageVms.Customers
{
    /// <summary>
    /// Müşteri listeleme sayfası için istek ve yanıt modellerini kapsayan view model.
    /// </summary>
    public class CustomerIndexPageVm
    {
        /// <summary>
        /// Sayfadan gelen arama kriterlerini tutar.
        /// </summary>
        public CustomerIndexRequestModel Request { get; set; } = new CustomerIndexRequestModel();

        /// <summary>
        /// BLL’den dönen müşteri listesini içerir.
        /// </summary>
        public CustomerIndexResponseModel Response { get; set; } = new CustomerIndexResponseModel();
    }
}
