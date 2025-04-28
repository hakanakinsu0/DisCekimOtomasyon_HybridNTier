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

            // Müşteri → Rezervasyon
            builder.HasOne(r => r.Customer)
                   .WithMany(c => c.Reservations)
                   .HasForeignKey(r => r.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Lokasyon → Rezervasyon
            builder.HasOne(r => r.Location)
                   .WithMany(l => l.Reservations)
                   .HasForeignKey(r => r.LocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Fotoğrafçı → Rezervasyon
            builder.HasOne(r => r.Photographer)
                   .WithMany(p => p.Reservations)
                   .HasForeignKey(r => r.PhotographerId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Kategori → Rezervasyon
            builder.HasOne(r => r.ServiceCategory)
                   .WithMany(sc => sc.Reservations)
                   .HasForeignKey(r => r.ServiceCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

 

            // Paket → Rezervasyon
            builder.HasOne(r => r.PackageOption)
                   .WithMany(po => po.Reservations)
                   .HasForeignKey(r => r.PackageOptionId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Rezervasyona bağlı ekstra seçimler
            builder.HasMany(r => r.ReservationExtras)
                   .WithOne(re => re.Reservation)
                   .HasForeignKey(re => re.ReservationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.AppUser)
                   .WithMany()  // eğer AppUser içinde ICollection<Reservation> eklemediyseniz
                   .HasForeignKey(r => r.AppUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
