using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.PackageExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.PackageExtras;

namespace Project.MvcUI.Models.PageVms.PackageExtras
{
    /// <summary>
    /// Paket-ekstra oluşturma sayfası için istek, yanıt modelleri ve dropdown listelerini içerir.
    /// </summary>
    public class PackageExtraCreatePageVm
    {
        public PackageExtraCreateRequestModel Request { get; set; } = new PackageExtraCreateRequestModel();
        public PackageExtraCreateResponseModel Response { get; set; } = new PackageExtraCreateResponseModel();
        public List<SelectListItem> PackageOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ExtraServices { get; set; } = new List<SelectListItem>();
    }
}
