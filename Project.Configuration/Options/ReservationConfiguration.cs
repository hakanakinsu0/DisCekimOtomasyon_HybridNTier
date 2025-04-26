using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configuration.Options
{
    public class ReservationConfiguration : BaseConfiguration<Reservation>
    {
        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            base.Configure(builder);

            builder.HasOne(r => r.Customer)
                   .WithMany(c => c.Reservations)
                   .HasForeignKey(r => r.CustomerId);

            builder.HasOne(r => r.Location)
                   .WithMany(l => l.Reservations)
                   .HasForeignKey(r => r.LocationId);

            builder.HasOne(r => r.Photographer)
                   .WithMany(p => p.Reservations)
                   .HasForeignKey(r => r.PhotographerId);
        }
    }
}
