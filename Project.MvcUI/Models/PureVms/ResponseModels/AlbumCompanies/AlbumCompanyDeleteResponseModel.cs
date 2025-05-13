namespace Project.MvcUI.Models.PureVms.ResponseModels.AlbumCompanies
{
    /// <summary>
    /// Albüm firması silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class AlbumCompanyDeleteResponseModel
    {
        public bool IsSuccess { get; set; }  // İşlem başarılı mı?
        public string? ErrorMessage { get; set; }  // Hata mesajı
    }
}
