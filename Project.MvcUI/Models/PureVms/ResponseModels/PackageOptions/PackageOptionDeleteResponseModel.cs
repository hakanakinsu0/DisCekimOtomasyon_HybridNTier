namespace Project.MvcUI.Models.PureVms.ResponseModels.PackageOptions
{
    /// <summary>
    /// Paket seçeneği silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class PackageOptionDeleteResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
