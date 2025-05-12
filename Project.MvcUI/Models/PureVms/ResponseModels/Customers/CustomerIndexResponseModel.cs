using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.Customers
{
    /// <summary>
    /// Müşteri listeleme sonucunda dönecek müşteri DTO’larını içerir.
    /// </summary>
    public class CustomerIndexResponseModel
    {
        /// <summary>
        /// Filtrelenmiş veya tüm müşteri DTO listesini tutar.
        /// </summary>
        public List<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
    }
}
