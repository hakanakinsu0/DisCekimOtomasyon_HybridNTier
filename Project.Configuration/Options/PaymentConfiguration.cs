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
    public class PaymentConfiguration : BaseConfiguration<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.TotalAmount)
                   .HasColumnType("money");

            builder.Property(p => p.PaidAmount)
                   .HasColumnType("money");

            builder.Property(p => p.RemainingAmount)
                   .HasColumnType("money");
        }
    }
}
