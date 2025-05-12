namespace Project.MvcUI.Models.PureVms.ResponseModels.ExtraServices
{
    /// <summary>
    /// Ekstra hizmet ekleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ExtraServiceCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
