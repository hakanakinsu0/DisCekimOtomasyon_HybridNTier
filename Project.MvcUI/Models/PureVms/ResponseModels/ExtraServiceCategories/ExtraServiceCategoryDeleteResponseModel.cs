namespace Project.MvcUI.Models.PureVms.ResponseModels.ExtraServiceCategories
{
    /// <summary>
    /// Silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ExtraServiceCategoryDeleteResponseModel
    {
        public bool IsSuccess { get; set; }  // İşlem başarılı mı?
        public string? ErrorMessage { get; set; }  // Hata varsa mesajı
    }
}
