using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DtoClasses
{
    public class PackageOptionDto : BaseDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
