using Project.MvcUI.Models.PureVms.RequestModels.PackageExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.PackageExtras;

namespace Project.MvcUI.Models.PageVms.PackageExtras
{
    /// <summary>
    /// Paket-ekstra silme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class PackageExtraDeletePageVm
    {
        public PackageExtraDeleteRequestModel Request { get; set; } = new PackageExtraDeleteRequestModel();
        public PackageExtraDeleteResponseModel Response { get; set; } = new PackageExtraDeleteResponseModel();
    }
}
