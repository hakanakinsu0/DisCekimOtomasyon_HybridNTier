namespace Project.MvcUI.Models.PureVms.ResponseModels.ReservationExtras
{
    /// <summary>
    /// Rezervasyona ait ekstra hizmet silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ReservationExtraDeleteResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
