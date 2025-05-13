using Project.MvcUI.Models.PureVms.RequestModels.SizeOptions;
using Project.MvcUI.Models.PureVms.ResponseModels.SizeOptions;

namespace Project.MvcUI.Models.PageVms.SizeOptions
{
    /// <summary>
    /// Ölçü seçeneği listeleme sayfası için ViewModel; hem istek hem yanıt modellerini taşır.
    /// </summary>
    public class SizeOptionIndexPageVm
    {
        public SizeOptionIndexRequestModel Request { get; set; } = new SizeOptionIndexRequestModel();
        public SizeOptionIndexResponseModel Response { get; set; } = new SizeOptionIndexResponseModel();
    }
}
