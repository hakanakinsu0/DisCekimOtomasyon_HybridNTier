namespace Project.MvcUI.Models.PureVms.ResponseModels.PackageOptions
{
    /// <summary>
    /// Paket seçeneği ekleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class PackageOptionCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
