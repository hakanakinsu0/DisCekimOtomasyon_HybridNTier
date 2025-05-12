namespace Project.MvcUI.Models.PureVms.ResponseModels.Locations
{
    /// <summary>
    /// Mekan düzenleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class LocationEditResponseModel
    {
        public bool IsSuccess { get; set; }      // İşlem başarılı mı?
        public string? ErrorMessage { get; set; }     // Hata varsa mesajı
    }
}
