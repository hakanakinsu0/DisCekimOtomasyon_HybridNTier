using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.PackageExtras
{
    /// <summary>
    /// Paket ekstra kayıtlarını içeren yanıt modelidir.
    /// </summary>
    public class PackageExtraIndexResponseModel
    {
        public List<PackageExtraDto> PackageExtras { get; set; } = new();  // DTO: PackageOptionId, ExtraServiceId, Quantity… 
    }
}
