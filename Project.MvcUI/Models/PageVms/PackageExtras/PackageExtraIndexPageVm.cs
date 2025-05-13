using Project.MvcUI.Models.PureVms.RequestModels.PackageExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.PackageExtras;

namespace Project.MvcUI.Models.PageVms.PackageExtras
{
    /// <summary>
    /// Paket ekstra liste sayfası için ViewModel; hem istek hem yanıt modellerini taşır.
    /// </summary>
    public class PackageExtraIndexPageVm
    {
        public PackageExtraIndexRequestModel Request { get; set; } = new PackageExtraIndexRequestModel();
        public PackageExtraIndexResponseModel Response { get; set; } = new PackageExtraIndexResponseModel();
    }
}
