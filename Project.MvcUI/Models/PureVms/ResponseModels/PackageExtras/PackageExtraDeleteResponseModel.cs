namespace Project.MvcUI.Models.PureVms.ResponseModels.PackageExtras
{
    /// <summary>
    /// Paket-ekstra silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class PackageExtraDeleteResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
