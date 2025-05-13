using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.ReservationExtras
{
    /// <summary>
    /// Rezervasyon ekstra hizmetleri listesini döner.
    /// </summary>
    public class ReservationExtraIndexResponseModel
    {
        public List<ReservationExtraDto> Items { get; set; } = new();
    }
}
