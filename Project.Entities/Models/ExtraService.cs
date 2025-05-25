using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Her bir ekstra hizmet seçeneğini tutar (örn. "30x40 Kanvas", "40x55 Lux Çerçeve" vb.) ve fiyatını belirtir.
    /// </summary>
    public class ExtraService : BaseEntity
    {
        //Foreign Keys
        public int ExtraServiceCategoryId { get; set; }

        //Properties
        public string Name { get; set; }
        public decimal Price { get; set; }

        //Relational Properties
        public virtual ExtraServiceCategory ExtraServiceCategory { get; set; } // 1 ExtraService 1 ExtraServiceCategory, 1 ExtraServiceCategory N ExtraService
    }
}
