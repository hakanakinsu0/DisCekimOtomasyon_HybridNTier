using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DtoClasses
{
    public class CustomerDto : BaseDto
    {
        public string BrideName { get; set; }
        public string GroomName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Email { get; set; }
    }
}
