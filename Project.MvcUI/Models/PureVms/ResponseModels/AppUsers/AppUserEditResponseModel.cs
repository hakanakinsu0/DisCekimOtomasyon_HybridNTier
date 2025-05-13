namespace Project.MvcUI.Models.PureVms.ResponseModels.AppUsers
{
    /// <summary>
    /// Kullanıcı güncelleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class AppUserEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
