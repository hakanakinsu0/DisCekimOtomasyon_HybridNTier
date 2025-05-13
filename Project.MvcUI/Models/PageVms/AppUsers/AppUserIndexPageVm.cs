using Project.MvcUI.Models.PureVms.RequestModels.AppUsers;
using Project.MvcUI.Models.PureVms.ResponseModels.AppUsers;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Index sayfası için hem arama isteğini hem de yanıt listesini barındırır.
    /// </summary>
    public class AppUserIndexPageVm
    {
        /// <summary>
        /// Arama kriterlerini içerir.
        /// </summary>
        public AppUserIndexRequestModel Request { get; set; } = new();

        /// <summary>
        /// Listelenen kullanıcıları içerir.
        /// </summary>
        public AppUserIndexResponseModel Response { get; set; } = new();
    }
}
