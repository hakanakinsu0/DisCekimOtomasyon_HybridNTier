using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PureVms.ResponseModels.AppUsers
{
    /// <summary>
    /// Kullanıcı listesini ve işlem sonucunu tutar.
    /// </summary>
    public class AppUserIndexResponseModel
    {
        /// <summary>
        /// Filtrelenmiş kullanıcı DTO listesi.
        /// </summary>
        public List<AppUserDto> Users { get; set; } = new();
    }
}
