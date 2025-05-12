using Project.MvcUI.Models.PureVms.RequestModels.ExtraServiceCategories;
using Project.MvcUI.Models.PureVms.ResponseModels.ExtraServiceCategories;

namespace Project.MvcUI.Models.PageVms.ExtraServiceCategories
{
    /// <summary>
    /// Ekstra hizmet kategorisi oluşturma sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ExtraServiceCategoryCreatePageVm
    {
        public ExtraServiceCategoryCreateRequestModel Request { get; set; } = new ExtraServiceCategoryCreateRequestModel();
        public ExtraServiceCategoryCreateResponseModel Response { get; set; } = new ExtraServiceCategoryCreateResponseModel();
    }
}
