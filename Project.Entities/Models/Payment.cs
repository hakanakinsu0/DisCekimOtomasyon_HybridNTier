using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Rezervasyona ait ödeme bilgilerini tutar.
    /// </summary>
    public class Payment : BaseEntity
    {
        //Foreign Keys
        public int ReservationId { get; set; }

        //Properties
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime? LastPaymentDate { get; set; }

        //Relational Properties
        public virtual Reservation Reservation { get; set; } // 1 Reservation N Payment, 1 Payment 1 Reservation
    }
}
