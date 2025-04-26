using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configuration.Options
{
    public class PackageExtraConfiguration : BaseConfiguration<PackageExtra>
    {
        public override void Configure(EntityTypeBuilder<PackageExtra> builder)
        {
            base.Configure(builder);
        }
    }
}
