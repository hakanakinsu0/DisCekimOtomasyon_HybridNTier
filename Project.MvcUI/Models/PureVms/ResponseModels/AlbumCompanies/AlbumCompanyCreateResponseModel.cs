namespace Project.MvcUI.Models.PureVms.ResponseModels.AlbumCompanies
{
    /// <summary>
    /// Albüm firması oluşturma işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class AlbumCompanyCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
