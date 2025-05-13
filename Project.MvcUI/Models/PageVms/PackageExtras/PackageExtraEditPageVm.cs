using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.PackageExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.PackageExtras;

namespace Project.MvcUI.Models.PageVms.PackageExtras
{
    /// <summary>
    /// Paket-ekstra düzenleme sayfası için istek, yanıt modelleri ve dropdown listelerini içerir.
    /// </summary>
    public class PackageExtraEditPageVm
    {
        public PackageExtraEditRequestModel Request { get; set; } = new PackageExtraEditRequestModel();
        public PackageExtraEditResponseModel Response { get; set; } = new PackageExtraEditResponseModel();
        public List<SelectListItem> PackageOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ExtraServices { get; set; } = new List<SelectListItem>();
    }
}
