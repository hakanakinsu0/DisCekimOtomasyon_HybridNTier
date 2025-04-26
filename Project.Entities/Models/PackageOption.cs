using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Seçilen ölçüye bakılmaksızın her zaman sunulan paket tiplerini tutar ("Tek Albüm", "Aile Albümü").
    /// </summary>
    public class PackageOption : BaseEntity
    {
        //Properties
        public string Name { get; set; }
        public decimal Price { get; set; }

        //Relational Properties 
        public virtual ICollection<PackageExtra> PackageExtras { get; set; } // 1 PackageOption N PackageExtra, 1 PackageExtra 1 PackageOption
    }
}
