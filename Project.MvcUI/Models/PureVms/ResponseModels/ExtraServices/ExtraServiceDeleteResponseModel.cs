namespace Project.MvcUI.Models.PureVms.ResponseModels.ExtraServices
{
    /// <summary>
    /// Ekstra hizmet silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ExtraServiceDeleteResponseModel
    {
        public bool IsSuccess { get; set; }  // İşlem başarılı mı?
        public string? ErrorMessage { get; set; }  // Hata mesajı
    }
}
