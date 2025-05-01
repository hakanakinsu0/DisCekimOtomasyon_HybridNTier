using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DtoClasses
{
    public class PackageExtraDto : BaseDto
    {
        public int PackageOptionId { get; set; }
        public int ExtraServiceId { get; set; }
        public int Quantity { get; set; }
    }
}
