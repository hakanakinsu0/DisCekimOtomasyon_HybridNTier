namespace Project.MvcUI.Models.PureVms.ResponseModels.ExtraServiceCategories
{
    /// <summary>
    /// Ekstra hizmet kategorisi oluşturma işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ExtraServiceCategoryCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
