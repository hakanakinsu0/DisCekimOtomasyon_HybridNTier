using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DtoClasses
{
    public class SizeOptionDto : BaseDto
    {
        public int ServiceCategoryId { get; set; }
        public string Dimension { get; set; }
    }
}
