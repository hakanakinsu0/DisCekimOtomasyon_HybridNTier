namespace Project.MvcUI.Models.PureVms.ResponseModels.AppUsers
{
    /// <summary>
    /// Kullanıcı oluşturma sonucunu ve hata mesajını tutar.
    /// </summary>
    public class AppUserCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
