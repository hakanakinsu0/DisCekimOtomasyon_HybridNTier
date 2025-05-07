using Project.MvcUI.Models.PureVms.RequestModels.Photographers;
using Project.MvcUI.Models.PureVms.ResponseModel.Photographers;

namespace Project.MvcUI.Models.PageVms.Photographers
{
    /// <summary>
    /// Fotoğrafçı düzenleme işlemi için gerekli istek ve yanıt verilerini tutan view model.
    /// </summary>
    public class PhotographerEditPageVm
    {
        // Düzenleme formundan gelen fotoğrafçı bilgilerini ve Id değerini içerir.
        public PhotographerEditRequestModel Request { get; set; } = new PhotographerEditRequestModel();

        // Düzenleme işleminin sonucunu (başarı durumu ve hata mesajı) içerir.
        public PhotographerEditResponseModel Response { get; set; } = new PhotographerEditResponseModel();
    }
}
