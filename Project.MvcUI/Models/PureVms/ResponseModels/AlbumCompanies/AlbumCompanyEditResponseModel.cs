namespace Project.MvcUI.Models.PureVms.ResponseModels.AlbumCompanies
{
    /// <summary>
    /// Albüm firması güncelleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class AlbumCompanyEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
