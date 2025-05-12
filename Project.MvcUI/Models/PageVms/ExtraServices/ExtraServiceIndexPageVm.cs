using Project.MvcUI.Models.PureVms.RequestModels.ExtraServices;
using Project.MvcUI.Models.PureVms.ResponseModels.ExtraServices;

namespace Project.MvcUI.Models.PageVms.ExtraServices
{
    /// <summary>
    /// Ekstra hizmetler listesi sayfası için istek ve yanıt modellerini kapsar.
    /// </summary>
    public class ExtraServiceIndexPageVm
    {
        // Kullanıcının arama terimini içerir
        public ExtraServiceIndexRequestModel Request { get; set; } = new ExtraServiceIndexRequestModel();

        // BLL’den dönen hizmet listesini tutar
        public ExtraServiceIndexResponseModel Response { get; set; } = new ExtraServiceIndexResponseModel();
    }
}
