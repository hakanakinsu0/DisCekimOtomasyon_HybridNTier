using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configuration.Options
{
    public class PhotographerConfiguration : BaseConfiguration<Photographer>
    {
        public override void Configure(EntityTypeBuilder<Photographer> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Fee)
                   .HasColumnType("money");
        }
    }
}
