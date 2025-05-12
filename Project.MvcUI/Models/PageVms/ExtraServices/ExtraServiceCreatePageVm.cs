using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.ExtraServices;
using Project.MvcUI.Models.PureVms.ResponseModels.ExtraServices;

namespace Project.MvcUI.Models.PageVms.ExtraServices
{
    /// <summary>
    /// Ekstra hizmet oluşturma sayfası için istek ve yanıt modellerini kapsayan view model.
    /// </summary>
    public class ExtraServiceCreatePageVm
    {
        public ExtraServiceCreateRequestModel Request { get; set; } = new();
        public ExtraServiceCreateResponseModel Response { get; set; } = new();

        // Kategori dropdown’u için
        public List<SelectListItem> Categories { get; set; } = new();
    }
}
