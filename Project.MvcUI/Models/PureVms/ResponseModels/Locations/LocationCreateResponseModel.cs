namespace Project.MvcUI.Models.PureVms.ResponseModels.Locations
{
    /// <summary>
    /// Mekan ekleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class LocationCreateResponseModel
    {
        public bool IsSuccess { get; set; }      // İşlem başarılı mı?
        public string? ErrorMessage { get; set; }     // Hata varsa mesajı
    }
}
