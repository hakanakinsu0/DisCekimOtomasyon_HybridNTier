namespace Project.MvcUI.Models.PureVms.ResponseModels.PackageExtras
{
    /// <summary>
    /// Paket-ekstra güncelleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class PackageExtraEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
