using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Bir rezervasyona eklenmiş ekstra baskı hizmetini ve miktarını tutar.
    /// </summary>
    public class ReservationExtra : BaseEntity
    {
        public int ReservationId { get; set; }
        public int ExtraServiceId { get; set; }
        public int Quantity { get; set; }

        //Relational Properties
        public virtual Reservation Reservation { get; set; }
        public virtual ExtraService ExtraService { get; set; }
    }
}
