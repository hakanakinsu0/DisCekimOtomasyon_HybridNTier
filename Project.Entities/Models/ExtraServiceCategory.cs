using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Ekstra hizmetlerin ana gruplarını tutar (örn. "Kanvas", "Çerçeve", "Saat").
    /// </summary>
    public class ExtraServiceCategory : BaseEntity
    {
        //Properties
        public string Name { get; set; }

        //Relational Properties
        public virtual ICollection<ExtraService> ExtraServices { get; set; }
    }
}
