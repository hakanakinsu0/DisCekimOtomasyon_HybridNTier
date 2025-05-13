using Project.MvcUI.Models.PureVms.RequestModels.SizeOptions;
using Project.MvcUI.Models.PureVms.ResponseModels.SizeOptions;

namespace Project.MvcUI.Models.PageVms.SizeOptions
{
    /// <summary>
    /// Ölçü seçeneği silme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class SizeOptionDeletePageVm
    {
        public SizeOptionDeleteRequestModel Request { get; set; } = new SizeOptionDeleteRequestModel();
        public SizeOptionDeleteResponseModel Response { get; set; } = new SizeOptionDeleteResponseModel();
    }
}
