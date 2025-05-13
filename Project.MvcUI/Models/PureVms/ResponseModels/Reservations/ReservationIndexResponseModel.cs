using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.Reservations
{
    /// <summary>
    /// Rezervasyon listesini içeren yanıt modelidir.
    /// </summary>
    public class ReservationIndexResponseModel
    {
        public List<ReservationDto> Reservations { get; set; } = new();  // DTO: CustomerId, LocationId, ScheduledDate, ReservationStatus… :contentReference[oaicite:0]{index=0}:contentReference[oaicite:1]{index=1}
    }
}
