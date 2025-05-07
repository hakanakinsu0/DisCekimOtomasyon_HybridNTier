using Project.MvcUI.Models.PureVms.RequestModels.Photographers;
using Project.MvcUI.Models.PureVms.ResponseModel.Photographers;

namespace Project.MvcUI.Models.PageVms.Photographers
{
    /// <summary>
    /// Fotoğrafçı listeleme sayfası için gerekli istek ve yanıt verilerini tutan view model.
    /// </summary>
    public class PhotographerIndexPageVm
    {
        // Arama formundan gönderilen ad-soyad kriterini içerir.
        public PhotographerIndexRequestModel Request { get; set; }

        // Arama ve listeleme sonucu dönen fotoğrafçı DTO’larını içerir.
        public PhotographerIndexResponseModel Response { get; set; }
    }
}
