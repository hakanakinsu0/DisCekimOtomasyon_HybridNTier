using Project.MvcUI.Models.PureVms.RequestModels.ExtraServiceCategories;
using Project.MvcUI.Models.PureVms.ResponseModels.ExtraServiceCategories;

namespace Project.MvcUI.Models.PageVms.ExtraServiceCategories
{
    /// <summary>
    /// Ekstra hizmet kategorileri listeleme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ExtraServiceCategoryIndexPageVm
    {
        public ExtraServiceCategoryIndexRequestModel Request { get; set; } = new ExtraServiceCategoryIndexRequestModel();
        public ExtraServiceCategoryIndexResponseModel Response { get; set; } = new ExtraServiceCategoryIndexResponseModel();
    }
}
