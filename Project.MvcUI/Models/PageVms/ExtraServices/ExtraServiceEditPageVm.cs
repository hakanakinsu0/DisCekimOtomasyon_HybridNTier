using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.RequestModels.ExtraServices;
using Project.MvcUI.Models.PureVms.ResponseModels.ExtraServices;

namespace Project.MvcUI.Models.PageVms.ExtraServices
{
    /// <summary>
    /// Ekstra hizmet düzenleme sayfası için istek ve yanıt modellerini kapsayan view model.
    /// </summary>
    public class ExtraServiceEditPageVm
    {
        public ExtraServiceEditRequestModel Request { get; set; } = new ExtraServiceEditRequestModel();
        public ExtraServiceEditResponseModel Response { get; set; } = new ExtraServiceEditResponseModel();
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
