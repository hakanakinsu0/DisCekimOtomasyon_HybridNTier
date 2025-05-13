using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.ServiceCategories
{
    /// <summary>
    /// Servis kategorileri listesini tutar.
    /// </summary>
    public class ServiceCategoryIndexResponseModel
    {
        public List<ServiceCategoryDto> Categories { get; set; } = new List<ServiceCategoryDto>();
    }
}
