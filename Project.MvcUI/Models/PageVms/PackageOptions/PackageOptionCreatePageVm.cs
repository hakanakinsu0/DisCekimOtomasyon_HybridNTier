using Project.MvcUI.Models.PureVms.RequestModels.PackageOptions;
using Project.MvcUI.Models.PureVms.ResponseModels.PackageOptions;

namespace Project.MvcUI.Models.PageVms.PackageOptions
{
    /// <summary>
    /// Paket seçeneği oluşturma sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class PackageOptionCreatePageVm
    {
        public PackageOptionCreateRequestModel Request { get; set; } = new PackageOptionCreateRequestModel();
        public PackageOptionCreateResponseModel Response { get; set; } = new PackageOptionCreateResponseModel();
    }
}
