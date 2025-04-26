using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Dış çekimlerde görev alabilecek fotoğrafçıların iletişim bilgilerini tutar.
    /// </summary>
    public class Photographer : BaseEntity
    {
        //Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public decimal Fee { get; set; }

        //Relational Properties 
        public virtual ICollection<Reservation> Reservations { get; set; } // 1 Photographer N Reservation, 1 Reservation 1 Photographer

    }
}
