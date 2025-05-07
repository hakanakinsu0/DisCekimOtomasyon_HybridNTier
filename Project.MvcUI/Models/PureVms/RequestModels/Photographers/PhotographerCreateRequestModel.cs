using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.Photographers
{
    public class PhotographerCreateRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Telefon")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "{0} 11 haneli olmalıdır.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} negatif olamaz.")]
        [Display(Name = "Ücret (₺)")]
        public decimal Fee { get; set; }
    }
}
