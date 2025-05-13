using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.Reservations
{
    /// <summary>
    /// Mevcut rezervasyon düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class ReservationEditRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Müşteri")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Mekan")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Fotoğrafçı")]
        public int PhotographerId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Hizmet Kategorisi")]
        public int ServiceCategoryId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Paket Seçeneği")]
        public int PackageOptionId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Sorumlu Kullanıcı")]
        public int AppUserId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Planlanan Tarih")]
        public DateTime ScheduledDate { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Süre (saat)")]
        public TimeSpan Duration { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Rezervasyon Durumu")]
        public Project.Entities.Enums.ReservationStatus ReservationStatus { get; set; }
    }
}
