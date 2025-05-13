using Project.MvcUI.Models.PureVms.RequestModels.PackageOptions;
using Project.MvcUI.Models.PureVms.ResponseModels.PackageOptions;

namespace Project.MvcUI.Models.PageVms.PackageOptions
{
    /// <summary>
    /// Paket seçenekleri listeleme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class PackageOptionIndexPageVm
    {
        public PackageOptionIndexRequestModel Request { get; set; } = new PackageOptionIndexRequestModel();
        public PackageOptionIndexResponseModel Response { get; set; } = new PackageOptionIndexResponseModel();
    }
}
