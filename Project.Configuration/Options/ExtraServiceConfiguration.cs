﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configuration.Options
{
    public class ExtraServiceConfiguration : BaseConfiguration<ExtraService>
    {
        public override void Configure(EntityTypeBuilder<ExtraService> builder)
        {
            base.Configure(builder);

            builder.Property(es => es.Price)
                   .HasColumnType("money");
        }
    }
}
