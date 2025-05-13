using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.SizeOptions
{
    /// <summary>
    /// Ölçü seçenekleri listesini içeren yanıt modelidir.
    /// </summary>
    public class SizeOptionIndexResponseModel
    {
        public List<SizeOptionDto> SizeOptions { get; set; } = new();  // DTO: ServiceCategoryId, Dimension… 
    }
}
