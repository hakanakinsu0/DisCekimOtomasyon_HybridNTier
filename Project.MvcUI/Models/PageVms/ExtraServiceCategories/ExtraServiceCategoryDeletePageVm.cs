using Project.MvcUI.Models.PureVms.RequestModels.ExtraServiceCategories;
using Project.MvcUI.Models.PureVms.ResponseModels.ExtraServiceCategories;

namespace Project.MvcUI.Models.PageVms.ExtraServiceCategories
{
    /// <summary>
    /// Kategori silme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ExtraServiceCategoryDeletePageVm
    {
        public ExtraServiceCategoryDeleteRequestModel Request { get; set; } = new ExtraServiceCategoryDeleteRequestModel();
        public ExtraServiceCategoryDeleteResponseModel Response { get; set; } = new ExtraServiceCategoryDeleteResponseModel();
    }
}
