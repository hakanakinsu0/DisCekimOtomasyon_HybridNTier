using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ServiceCategories
{
    /// <summary>
    /// Silinecek servis kategorisi bilgilerini tutar.
    /// </summary>
    public class ServiceCategoryDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }               // Silinecek kategori Id’si

        public string Name { get; set; } = "";    // Onay ekranında gösterilecek kategori adı
    }
}
