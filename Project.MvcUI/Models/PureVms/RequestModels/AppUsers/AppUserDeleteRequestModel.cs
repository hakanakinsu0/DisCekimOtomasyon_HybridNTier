using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.AppUsers
{
    /// <summary>
    /// Silinecek kullanıcı Id’sini ve onay metnini tutar.
    /// </summary>
    public class AppUserDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }                  // Silinecek kullanıcının Id’si

        public string Username { get; set; } = "";   // Onay ekranında gösterilecek kullanıcı adı
    }
}
