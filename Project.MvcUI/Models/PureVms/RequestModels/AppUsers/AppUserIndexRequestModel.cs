namespace Project.MvcUI.Models.PureVms.RequestModels.AppUsers
{
    /// <summary>
    /// Kullanıcı listesi için arama terimini tutar.
    /// </summary>
    public class AppUserIndexRequestModel
    {
        /// <summary>
        /// Kullanıcı adı veya e-posta ile filtreleme için arama metni.
        /// </summary>
        public string? SearchTerm { get; set; }
    }
}
