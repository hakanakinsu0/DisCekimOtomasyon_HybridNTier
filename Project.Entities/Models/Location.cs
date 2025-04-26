using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Dış çekim yapılabilecek mekânın bilgilerini tutar.
    /// </summary>
    public class Location : BaseEntity
    {
        //Properties
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }    
        public string City { get; set; }    
        public string? Phone { get; set; }
        public bool IsFree { get; set; }
        public decimal? Price { get; set; }

        //Relational Properties
        public virtual ICollection<Reservation> Reservations { get; set; } // 1 Location N Reservation, 1 Reservation 1 Location

    }
}
