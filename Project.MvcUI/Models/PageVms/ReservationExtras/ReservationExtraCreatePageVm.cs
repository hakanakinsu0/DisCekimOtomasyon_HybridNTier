using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.DtoClasses;
using Project.MvcUI.Models.PureVms.RequestModels.ReservationExtras;
using Project.MvcUI.Models.PureVms.ResponseModels.ReservationExtras;

namespace Project.MvcUI.Models.PageVms.ReservationExtras
{
    /// <summary>
    /// Rezervasyona ekstra hizmet ekleme sayfası için istek/yanıt modelleri ve dropdown verilerini içerir.
    /// </summary>
    public class ReservationExtraCreatePageVm
    {
        // Formdan gelen verileri tutar
        public ReservationExtraCreateRequestModel Request { get; set; }
            = new ReservationExtraCreateRequestModel();

        // İşlem sonucunu tutar
        public ReservationExtraCreateResponseModel Response { get; set; }
            = new ReservationExtraCreateResponseModel();

        // Hangi rezervasyon için çalışıyoruz
        public int ReservationId { get; set; }

        // Seçilen paket opsiyonunun ID'si
        public int PackageOptionId { get; set; }

        // Seçilen paketin taban fiyatı
        public decimal PackagePrice { get; set; }

        // Kullanıcının seçtiği ekstra hizmet ID'leri
        public List<int> SelectedExtraIds { get; set; }
            = new List<int>();

        // Dropdown için ekstra hizmet listesi
        public List<SelectListItem> ExtraServices { get; set; }
            = new List<SelectListItem>();


        // GET tarafı için
        public List<ExtraServiceCategoryDto> Categories { get; set; } = new();
        public List<ExtraServiceDto> Services { get; set; } = new();

        // Zaten ekli olanları ön tanımlamak için
        public Dictionary<int, int> ExistingCounts { get; set; } = new();

        // POST tarafı için: servisId → quantity
        public Dictionary<int, int> SelectedExtras { get; set; } = new();
    }
}
