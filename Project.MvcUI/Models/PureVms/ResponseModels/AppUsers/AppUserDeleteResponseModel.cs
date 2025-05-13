namespace Project.MvcUI.Models.PureVms.ResponseModels.AppUsers
{
    /// <summary>
    /// Silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class AppUserDeleteResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
