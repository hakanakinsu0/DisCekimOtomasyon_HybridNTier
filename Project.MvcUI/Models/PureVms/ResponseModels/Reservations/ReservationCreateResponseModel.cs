namespace Project.MvcUI.Models.PureVms.ResponseModels.Reservations
{
    /// <summary>
    /// Rezervasyon oluşturma işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ReservationCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
