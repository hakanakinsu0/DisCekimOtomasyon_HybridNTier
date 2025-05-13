using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.ServiceCategories;
using Project.MvcUI.Models.PureVms.ResponseModels.ServiceCategories;

namespace Project.MvcUI.Models.PageVms.ServiceCategories
{
    /// <summary>
    /// Servis kategorisi düzenleme sayfası için istek, yanıt modelleri ve dropdown listesini içerir.
    /// </summary>
    public class ServiceCategoryEditPageVm
    {
        public ServiceCategoryEditRequestModel Request { get; set; } = new ServiceCategoryEditRequestModel();
        public ServiceCategoryEditResponseModel Response { get; set; } = new ServiceCategoryEditResponseModel();
        public List<SelectListItem> Companies { get; set; } = new List<SelectListItem>();
    }
}
