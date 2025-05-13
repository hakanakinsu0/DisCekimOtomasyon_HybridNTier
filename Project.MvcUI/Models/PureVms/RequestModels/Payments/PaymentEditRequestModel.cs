using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.Payments
{
    /// <summary>
    /// Mevcut ödeme düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class PaymentEditRequestModel
    {
        [Required]
        public int Id { get; set; }  // Düzenlenecek ödemenin Id’si

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Rezervasyon")]
        public int ReservationId { get; set; }  // Hangi rezervasyona ait olduğu

        [Required(ErrorMessage = "{0} zorunludur.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Toplam Tutar")]
        public decimal TotalAmount { get; set; }  // Referans toplam tutar

        [Required(ErrorMessage = "{0} zorunludur.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Ödenen Tutar")]
        public decimal PaidAmount { get; set; }   // Bu işlemde ödenen miktar
    }
}
