using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Her bir hizmet kategorisi için sunulan ölçü seçeneklerini temsil eder.
    /// </summary>
    public class SizeOption : BaseEntity
    {
        //Foreign Keys
        public int ServiceCategoryId { get; set; }

        //Properties
        public string Dimension { get; set; }

        //Relational Properties
        public virtual ServiceCategory ServiceCategory { get; set; } // 1 SizeOption 1 ServiceCategory, 1 ServiceCategory N SizeOption
    }
}
