namespace Project.MvcUI.Models.PureVms.ResponseModels.Reservations
{
    /// <summary>
    /// Rezervasyon silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ReservationDeleteResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
