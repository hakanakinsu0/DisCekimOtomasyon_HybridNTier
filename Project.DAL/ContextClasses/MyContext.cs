using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Configuration.Options;
using Project.DAL.BogusHandling;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.ContextClasses
{
    public class MyContext : IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        /// <summary>
        /// MyContext constructor'ı, dışarıdan gelen DbContextOptions ile başlatılır.
        /// </summary>
        /// <param name="opt">Veritabanı bağlantı seçenekleri</param>
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {
        }

        /// <summary>
        /// Veritabani konfigurasyon ayarlamalari uygulanir.
        /// Tüm entity'lerin yapılandırmaları ApplyConfiguration() ile yüklenir.
        /// </summary>
        /// <param name="builder">Model yapılandırması</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new PhotographerConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new PaymentConfiguration());
            builder.ApplyConfiguration(new AlbumCompanyConfiguration());
            builder.ApplyConfiguration(new ServiceCategoryConfiguration());
            builder.ApplyConfiguration(new SizeOptionConfiguration());
            builder.ApplyConfiguration(new PackageOptionConfiguration());
            builder.ApplyConfiguration(new ExtraServiceCategoryConfiguration());
            builder.ApplyConfiguration(new ExtraServiceConfiguration());
            builder.ApplyConfiguration(new ReservationExtraConfiguration());

            // Seed (Başlangıç) Verileri Burada Çağrılır
            UserAndRoleSeed.SeedAdminUser(builder);
            AlbumCompanySeed.SeedAlbumCompanies(builder);
            PhotographerSeed.SeedPhotographers(builder);
            LocationSeed.SeedLocations(builder);
            ExtraServiceCategorySeed.SeedExtraServiceCategories(builder);
            ServiceCategorySeed.SeedServiceCategories(builder);
            SizeOptionSeed.SeedSizeOptions(builder);
            ExtraServiceSeed.SeedExtraServices(builder);
        }

        // Veritabanı Tabloları
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Photographer> Photographers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<AlbumCompany> AlbumCompanies { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<SizeOption> SizeOptions { get; set; }
        public DbSet<PackageOption> PackageOptions { get; set; }
        public DbSet<ExtraServiceCategory> ExtraServiceCategories { get; set; }
        public DbSet<ExtraService> ExtraServices { get; set; }
        public DbSet<ReservationExtra> ReservationExtras { get; set; }
    }
}
