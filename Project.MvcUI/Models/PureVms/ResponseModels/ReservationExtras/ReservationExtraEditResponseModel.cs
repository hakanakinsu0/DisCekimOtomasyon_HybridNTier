namespace Project.MvcUI.Models.PureVms.ResponseModels.ReservationExtras
{
    /// <summary>
    /// Rezervasyona ait ekstra hizmet güncelleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ReservationExtraEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
