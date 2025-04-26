using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configuration.Options
{
    public class ServiceCategoryConfiguration : BaseConfiguration<ServiceCategory>
    {
        public override void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            base.Configure(builder);
        }
    }
}
