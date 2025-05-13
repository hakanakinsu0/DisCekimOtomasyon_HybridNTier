using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.AlbumCompanies
{
    /// <summary>
    /// Silinecek albüm firması bilgilerini tutar.
    /// </summary>
    public class AlbumCompanyDeleteRequestModel
    {
        [Required]
        public int Id { get; set; }               // Silinecek firma Id’si

        public string Name { get; set; } = "";    // Onay ekranında gösterilecek firma adı
    }
}
