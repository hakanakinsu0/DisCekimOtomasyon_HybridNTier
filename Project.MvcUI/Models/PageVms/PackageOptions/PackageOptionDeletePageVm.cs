using Project.MvcUI.Models.PureVms.RequestModels.PackageOptions;
using Project.MvcUI.Models.PureVms.ResponseModels.PackageOptions;

namespace Project.MvcUI.Models.PageVms.PackageOptions
{
    /// <summary>
    /// Paket seçeneği silme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class PackageOptionDeletePageVm
    {
        public PackageOptionDeleteRequestModel Request { get; set; } = new PackageOptionDeleteRequestModel();
        public PackageOptionDeleteResponseModel Response { get; set; } = new PackageOptionDeleteResponseModel();
    }
}
