using Project.MvcUI.Models.PureVms.RequestModels.Photographers;
using Project.MvcUI.Models.PureVms.ResponseModel.Photographers;

namespace Project.MvcUI.Models.PageVms.Photographers
{
    /// <summary>
    /// Fotoğrafçı silme işlemi için gerekli istek ve yanıt verilerini tutan view model.
    /// </summary>
    public class PhotographerDeletePageVm
    {
        // Silinecek fotoğrafçının Id ve görüntülenecek adı-soyad bilgisini içerir.
        public PhotographerDeleteRequestModel Request { get; set; } = new PhotographerDeleteRequestModel();

        // Silme işleminin sonucunu (başarılı/başarısız) ve hata mesajını içerir.
        public PhotographerDeleteResponseModel Response { get; set; } = new PhotographerDeleteResponseModel();
    }
}
