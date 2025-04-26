using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Albüm firmasının sunduğu ana hizmet kategorilerini tutar.
    /// Örnek: “New Line Collection”, “Standart”, “Kampanya”, “Çizgi Avantaj”
    /// </summary>
    public class ServiceCategory : BaseEntity
    {
        //Foreign Keys
        public int AlbumCompanyId { get; set; }

        //Properties
        public string Name { get; set; }

        //Relational Properties
        public virtual AlbumCompany AlbumCompany { get; set; }              // 1 AlbumCompany N ServiceCategory, 1 ServiceCategory 1 AlbumCompany
        public virtual ICollection<SizeOption> SizeOptions { get; set; }    // 1 ServiceCategory N SizeOption, 1 SizeOption 1 ServiceCategory
    }
}
