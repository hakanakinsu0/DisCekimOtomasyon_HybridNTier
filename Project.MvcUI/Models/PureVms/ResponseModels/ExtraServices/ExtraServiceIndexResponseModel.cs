using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.ExtraServices
{
    /// <summary>
    /// Ekstra hizmet listesinin veri taşıyıcısı.
    /// </summary>
    public class ExtraServiceIndexResponseModel
    {
        public List<ExtraServiceDto> ExtraServices { get; set; } = new List<ExtraServiceDto>();
    }
}
