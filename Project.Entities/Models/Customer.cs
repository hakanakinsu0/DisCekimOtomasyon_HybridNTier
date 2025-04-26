using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Dış çekim için gelin ve damat iletişim bilgilerini tutar.
    /// </summary>
    public class Customer : BaseEntity
    {
        //Properties
        public string BrideName { get; set; }
        public string GroomName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Email { get; set; }

        //Relational Properties
        public virtual ICollection<Reservation> Reservations { get; set; } // 1 Customer N Reservation, 1 Reservation 1 Customer
    }
}
