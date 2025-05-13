using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.ServiceCategories;
using Project.MvcUI.Models.PureVms.ResponseModels.ServiceCategories;

namespace Project.MvcUI.Models.PageVms.ServiceCategories
{
    /// <summary>
    /// Servis kategorisi oluşturma sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ServiceCategoryCreatePageVm
    {
        public ServiceCategoryCreateRequestModel Request { get; set; } = new();
        public ServiceCategoryCreateResponseModel Response { get; set; } = new();
        public List<SelectListItem> Companies { get; set; } = new(); // Yeni eklendi
    }
}
