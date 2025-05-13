namespace Project.MvcUI.Models.PureVms.ResponseModels.ServiceCategories
{
    /// <summary>
    /// Servis kategorisi silme işleminin sonucunu ve hata mesajını tutar.
    /// </summary>
    public class ServiceCategoryDeleteResponseModel
    {
        public bool IsSuccess { get; set; }  // İşlem başarılı mı?
        public string? ErrorMessage { get; set; }  // Hata mesajı
    }
}
