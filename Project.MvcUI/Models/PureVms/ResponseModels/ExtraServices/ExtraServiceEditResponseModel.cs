namespace Project.MvcUI.Models.PureVms.ResponseModels.ExtraServices
{
    /// <summary>
    /// Ekstra hizmet düzenleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ExtraServiceEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
