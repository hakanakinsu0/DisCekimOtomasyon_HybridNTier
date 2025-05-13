namespace Project.MvcUI.Models.PureVms.ResponseModels.SizeOptions
{
    /// <summary>
    /// Ölçü seçeneği güncelleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class SizeOptionEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
