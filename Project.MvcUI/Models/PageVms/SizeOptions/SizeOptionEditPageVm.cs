using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.SizeOptions;
using Project.MvcUI.Models.PureVms.ResponseModels.SizeOptions;

namespace Project.MvcUI.Models.PageVms.SizeOptions
{
    /// <summary>
    /// Ölçü seçeneği düzenleme sayfası için istek, yanıt modelleri ve kategori listelerini içerir.
    /// </summary>
    public class SizeOptionEditPageVm
    {
        public SizeOptionEditRequestModel Request { get; set; } = new SizeOptionEditRequestModel();
        public SizeOptionEditResponseModel Response { get; set; } = new SizeOptionEditResponseModel();
        public List<SelectListItem> ServiceCategories { get; set; } = new List<SelectListItem>();
    }
}
