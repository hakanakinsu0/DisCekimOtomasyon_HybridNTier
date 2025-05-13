namespace Project.MvcUI.Models.PureVms.ResponseModels.ServiceCategories
{
    /// <summary>
    /// Servis kategorisi güncelleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ServiceCategoryEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
