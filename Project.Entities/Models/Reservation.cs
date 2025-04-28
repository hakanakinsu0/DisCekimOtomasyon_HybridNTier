using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Çekim rezervasyon bilgilerini, müşteriyi, mekânı, fotoğrafçıyı ve iş akışı durumunu tutar.
    /// </summary>
    public class Reservation : BaseEntity
    {
        //Foreign Keys
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int PhotographerId { get; set; }
        public int ServiceCategoryId { get; set; }
        public int PackageOptionId { get; set; }
        public int AppUserId { get; set; }

        //Properties
        public DateTime ScheduledDate { get; set; }
        public TimeSpan Duration { get; set; }
        public ReservationStatus ReservationStatus { get; set; }

        //Relational Properties
        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual Photographer Photographer { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }
        public virtual PackageOption PackageOption { get; set; }
        public virtual ICollection<ReservationExtra> ReservationExtras { get; set; }
        public virtual AppUser AppUser { get; set; }


    }
}
