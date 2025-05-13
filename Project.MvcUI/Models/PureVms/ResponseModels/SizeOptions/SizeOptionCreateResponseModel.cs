namespace Project.MvcUI.Models.PureVms.ResponseModels.SizeOptions
{
    /// <summary>
    /// Ölçü seçeneği oluşturma işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class SizeOptionCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
