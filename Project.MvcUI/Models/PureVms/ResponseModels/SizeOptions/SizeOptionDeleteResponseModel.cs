namespace Project.MvcUI.Models.PureVms.ResponseModels.SizeOptions
{
    /// <summary>
    /// Ölçü seçeneği silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class SizeOptionDeleteResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
