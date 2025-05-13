namespace Project.MvcUI.Models.PureVms.ResponseModels.PackageExtras
{
    /// <summary>
    /// Paket-ekstra ekleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class PackageExtraCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
