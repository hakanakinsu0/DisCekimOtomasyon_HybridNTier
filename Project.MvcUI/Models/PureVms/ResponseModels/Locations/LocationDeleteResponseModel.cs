namespace Project.MvcUI.Models.PureVms.ResponseModels.Locations
{
    /// <summary>
    /// Mekan silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class LocationDeleteResponseModel
    {
        public bool IsSuccess { get; set; }      // İşlem başarılı mı?
        public string? ErrorMessage { get; set; }     // Başarısızsa mesaj
    }
}
