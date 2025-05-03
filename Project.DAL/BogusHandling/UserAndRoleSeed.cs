using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.BogusHandling
{
    public static class UserAndRoleSeed
    {
        public static void SeedAdminUser(ModelBuilder modelBuilder)
        {
            // Admin rolünü ekle
            IdentityRole<int> adminRole = new() 
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            modelBuilder.Entity<IdentityRole<int>>().HasData(adminRole);

            // Admin kullanıcısını oluştur
            PasswordHasher<AppUser> hasher = new();
            AppUser adminUser = new()
            {
                Id = 1,
                UserName = "fotoeylul",
                NormalizedUserName = "FOTOEYLUL",
                Email = "fotoeylul@email.com",
                NormalizedEmail = "FOTOEYLUL@EMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "fotoeylul"),
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };
            modelBuilder.Entity<AppUser>().HasData(adminUser);

            // Kullanıcıya Admin rolünü ata
            IdentityUserRole<int> adminUserRole = new()
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id
            };
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRole);
        }
    }
}
