using Project.MvcUI.Models.PureVms.RequestModels.PackageOptions;
using Project.MvcUI.Models.PureVms.ResponseModels.PackageOptions;

namespace Project.MvcUI.Models.PageVms.PackageOptions
{
    /// <summary>
    /// Paket seçeneği düzenleme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class PackageOptionEditPageVm
    {
        public PackageOptionEditRequestModel Request { get; set; } = new PackageOptionEditRequestModel();
        public PackageOptionEditResponseModel Response { get; set; } = new PackageOptionEditResponseModel();
    }
}
