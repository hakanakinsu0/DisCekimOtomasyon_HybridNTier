namespace Project.MvcUI.Models.PureVms.ResponseModels.Reservations
{
    /// <summary>
    /// Rezervasyon güncelleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ReservationEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
