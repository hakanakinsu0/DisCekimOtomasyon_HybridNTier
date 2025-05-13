using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.SizeOptions;
using Project.MvcUI.Models.PureVms.ResponseModels.SizeOptions;

namespace Project.MvcUI.Models.PageVms.SizeOptions
{
    /// <summary>
    /// Ölçü seçeneği oluşturma sayfası için istek, yanıt modelleri ve kategori listelerini içerir.
    /// </summary>
    public class SizeOptionCreatePageVm
    {
        public SizeOptionCreateRequestModel Request { get; set; } = new SizeOptionCreateRequestModel();
        public SizeOptionCreateResponseModel Response { get; set; } = new SizeOptionCreateResponseModel();
        public List<SelectListItem> ServiceCategories { get; set; } = new List<SelectListItem>();
    }
}
