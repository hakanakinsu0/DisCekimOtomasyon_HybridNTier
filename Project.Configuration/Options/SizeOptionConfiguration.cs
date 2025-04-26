using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configuration.Options
{
    public class SizeOptionConfiguration : BaseConfiguration<SizeOption>
    {
        public override void Configure(EntityTypeBuilder<SizeOption> builder)
        {
            base.Configure(builder);
        }
    }
}
