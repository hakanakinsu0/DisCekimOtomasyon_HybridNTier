using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Hangi pakete hangi ekstra hizmetlerin eklendiğini ve adedini tutar.
    /// </summary>
    public class PackageExtra : BaseEntity
    {
        //Foreign Keys
        public int PackageOptionId { get; set; }
        public int ExtraServiceId { get; set; }

        //Properties
        public int Quantity { get; set; }

        //Relational Properties
        public virtual PackageOption PackageOption { get; set; } // 1 PackageExtra 1 PackageOption, 1 PackageOption N PackageExtra
        public virtual ExtraService ExtraService { get; set; } // 1 PackageExtra 1 ExtraService, 1 ExtraService N PackageExtra
    }
}
