namespace Project.MvcUI.Models.PureVms.ResponseModels.PackageOptions
{
    /// <summary>
    /// Paket seçeneği güncelleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class PackageOptionEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
