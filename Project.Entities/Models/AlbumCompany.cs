using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Albüm ve ekstra baskı hizmeti sunan tedarikçi firmanın temel iletişim bilgilerini tutar.
    /// </summary>
    public class AlbumCompany : BaseEntity
    {
        //Properties
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ContactPersonName { get; set; }  
        public string? ContactPersonPhone { get; set; } 
        public string? ContactPersonEmail { get; set; }

        //Relational Properties
        public virtual ICollection<ServiceCategory> ServiceCategories { get; set; } // 1 AlbumCompany N ServiceCategory, 1 ServiceCategory 1 AlbumCompany
    }
}
