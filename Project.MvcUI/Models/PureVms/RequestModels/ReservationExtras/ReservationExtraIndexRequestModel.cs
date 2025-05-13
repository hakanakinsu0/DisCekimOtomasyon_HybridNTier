namespace Project.MvcUI.Models.PureVms.RequestModels.ReservationExtras
{
    /// <summary>
    /// Rezervasyona ait ekstra hizmetlerin listelenmesi için arama kriterini tutar.
    /// </summary>
    public class ReservationExtraIndexRequestModel
    {
        public string? SearchTerm { get; set; } // Rezervasyon Id, servis adı veya miktar ile arama
    }
}
