namespace Project.MvcUI.Models.PureVms.ResponseModel.Accounts
{
    public class LoginResponseModel
    {
        // Giriş işleminin başarılı olup olmadığı
        public bool IsSuccess { get; set; }

        // Başarısızsa gösterilecek hata mesajı
        public string? ErrorMessage { get; set; }
    }
}
