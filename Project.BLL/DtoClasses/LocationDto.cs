﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DtoClasses
{
    public class LocationDto : BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string? Phone { get; set; }
        public bool IsFree { get; set; }
        public decimal? Price { get; set; }
    }
}
