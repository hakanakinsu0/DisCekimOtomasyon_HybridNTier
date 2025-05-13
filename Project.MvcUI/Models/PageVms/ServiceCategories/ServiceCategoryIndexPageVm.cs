using Project.MvcUI.Models.PureVms.RequestModels.ServiceCategories;
using Project.MvcUI.Models.PureVms.ResponseModels.ServiceCategories;

namespace Project.MvcUI.Models.PageVms.ServiceCategories
{
    /// <summary>
    /// Servis kategorileri listeleme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ServiceCategoryIndexPageVm
    {
        public ServiceCategoryIndexRequestModel Request { get; set; } = new ServiceCategoryIndexRequestModel();
        public ServiceCategoryIndexResponseModel Response { get; set; } = new ServiceCategoryIndexResponseModel();
    }
}
