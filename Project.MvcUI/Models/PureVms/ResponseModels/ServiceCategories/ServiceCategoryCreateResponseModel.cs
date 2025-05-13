namespace Project.MvcUI.Models.PureVms.ResponseModels.ServiceCategories
{
    /// <summary>
    /// Servis kategorisi oluşturma işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ServiceCategoryCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
