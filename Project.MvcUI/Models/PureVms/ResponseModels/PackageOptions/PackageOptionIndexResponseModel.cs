using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.PackageOptions
{
    /// <summary>
    /// Paket seçenekleri listesini tutar.
    /// </summary>
    public class PackageOptionIndexResponseModel
    {
        public List<PackageOptionDto> PackageOptions { get; set; } = new List<PackageOptionDto>();
    }
}
