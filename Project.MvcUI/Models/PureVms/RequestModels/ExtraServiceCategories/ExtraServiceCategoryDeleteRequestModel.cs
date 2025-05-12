using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ExtraServiceCategories
{
    /// <summary>
    /// Silinecek ekstra hizmet kategorisi bilgilerini tutar.
    /// </summary>
    public class ExtraServiceCategoryDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }              // Silinecek kategori Id’si

        public string Name { get; set; } = "";   // Onay ekranında gösterilecek kategori adı
    }
}
