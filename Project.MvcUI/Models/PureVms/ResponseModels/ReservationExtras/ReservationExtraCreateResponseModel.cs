namespace Project.MvcUI.Models.PureVms.ResponseModels.ReservationExtras
{
    /// <summary>
    /// Rezervasyona ekstra hizmet ekleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ReservationExtraCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
