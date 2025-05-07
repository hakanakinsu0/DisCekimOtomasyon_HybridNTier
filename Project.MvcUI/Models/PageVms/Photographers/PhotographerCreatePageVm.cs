using Project.MvcUI.Models.PureVms.RequestModels.Photographers;
using Project.MvcUI.Models.PureVms.ResponseModel.Photographers;

namespace Project.MvcUI.Models.PageVms.Photographers
{
    /// <summary>
    /// Fotoğrafçı ekleme sayfası için hem istek hem de yanıt modellerini taşıyan view model.
    /// </summary>
    public class PhotographerCreatePageVm
    {
        //Kullanıcının form aracılığıyla gönderdiği yeni fotoğrafçı bilgilerini tutar.
        public PhotographerCreateRequestModel Request { get; set; } = new PhotographerCreateRequestModel();

        // İşlem sonucuna dair başarı durumu ve hata mesajlarını içerir.
        public PhotographerCreateResponseModel Response { get; set; } = new PhotographerCreateResponseModel();
    }
}
