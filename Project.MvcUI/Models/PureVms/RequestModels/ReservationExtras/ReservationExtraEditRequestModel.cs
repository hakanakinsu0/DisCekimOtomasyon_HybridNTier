﻿using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.RequestModels.ReservationExtras
{
    /// <summary>
    /// Mevcut rezervasyona ait ekstra hizmet düzenleme formundan gelen verileri tutar.
    /// </summary>
    public class ReservationExtraEditRequestModel
    {
        [Required]
        public int Id { get; set; }  // Düzenlenecek kaydın Id’si

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Rezervasyon")]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Ekstra Hizmet")]
        public int ExtraServiceId { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} en az 1 olmalıdır.")]
        [Display(Name = "Miktar")]
        public int Quantity { get; set; }
    }
}
