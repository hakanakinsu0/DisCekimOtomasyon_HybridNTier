using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.ExtraServiceCategories
{
    /// <summary>
    /// Ekstra hizmet kategorileri listesini içerir.
    /// </summary>
    public class ExtraServiceCategoryIndexResponseModel
    {
        public List<ExtraServiceCategoryDto> Categories { get; set; } = new List<ExtraServiceCategoryDto>();
    }
}
