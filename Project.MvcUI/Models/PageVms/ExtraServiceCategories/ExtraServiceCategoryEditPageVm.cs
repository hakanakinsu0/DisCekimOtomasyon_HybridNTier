using Project.MvcUI.Models.PureVms.RequestModels.ExtraServiceCategories;
using Project.MvcUI.Models.PureVms.ResponseModels.ExtraServiceCategories;

namespace Project.MvcUI.Models.PageVms.ExtraServiceCategories
{
    /// <summary>
    /// Ekstra hizmet kategorisi düzenleme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ExtraServiceCategoryEditPageVm
    {
        public ExtraServiceCategoryEditRequestModel Request { get; set; } = new ExtraServiceCategoryEditRequestModel();
        public ExtraServiceCategoryEditResponseModel Response { get; set; } = new ExtraServiceCategoryEditResponseModel();
    }
}
