using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DtoClasses
{
    public class ReservationDto : BaseDto
    {
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int PhotographerId { get; set; }
        public int ServiceCategoryId { get; set; }
        public int PackageOptionId { get; set; }
        public int AppUserId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public TimeSpan Duration { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
    }
}
