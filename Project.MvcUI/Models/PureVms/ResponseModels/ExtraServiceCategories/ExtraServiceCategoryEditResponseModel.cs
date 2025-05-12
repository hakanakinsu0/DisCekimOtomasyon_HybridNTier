namespace Project.MvcUI.Models.PureVms.ResponseModels.ExtraServiceCategories
{
    /// <summary>
    /// Ekstra hizmet kategorisi düzenleme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ExtraServiceCategoryEditResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
