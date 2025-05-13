using Project.MvcUI.Models.PureVms.RequestModels.ServiceCategories;
using Project.MvcUI.Models.PureVms.ResponseModels.ServiceCategories;

namespace Project.MvcUI.Models.PageVms.ServiceCategories
{
    /// <summary>
    /// Servis kategorisi silme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ServiceCategoryDeletePageVm
    {
        public ServiceCategoryDeleteRequestModel Request { get; set; } = new ServiceCategoryDeleteRequestModel();
        public ServiceCategoryDeleteResponseModel Response { get; set; } = new ServiceCategoryDeleteResponseModel();
    }
}
