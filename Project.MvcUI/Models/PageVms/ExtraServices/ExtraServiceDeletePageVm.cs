using Project.MvcUI.Models.PureVms.RequestModels.ExtraServices;
using Project.MvcUI.Models.PureVms.ResponseModels.ExtraServices;

namespace Project.MvcUI.Models.PageVms.ExtraServices
{
    /// <summary>
    /// Ekstra hizmet silme sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ExtraServiceDeletePageVm
    {
        // Silinecek hizmetin bilgilerini içerir
        public ExtraServiceDeleteRequestModel Request { get; set; } = new ExtraServiceDeleteRequestModel();

        // Silme sonucunu ve mesajını içerir
        public ExtraServiceDeleteResponseModel Response { get; set; } = new ExtraServiceDeleteResponseModel();
    }
}
