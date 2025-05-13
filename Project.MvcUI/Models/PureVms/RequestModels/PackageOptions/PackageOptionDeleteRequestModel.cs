using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.PackageOptions
{
    /// <summary>
    /// Silinecek paket seçeneği bilgilerini tutar.
    /// </summary>
    public class PackageOptionDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }            // Silinecek seçeneğin Id’si

        public string Name { get; set; } = ""; // Onay ekranında gösterilecek adı
    }
}
