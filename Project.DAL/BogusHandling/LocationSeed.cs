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
    public static class LocationSeed
    {
        public static void SeedLocations(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            var locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    Name = "Nezahat Gökyiğit Botanik Bahçesi",
                    Address = "Yan Yol, Ataşehir, Rıfat Danışman Sok., 34758",
                    District = "Ataşehir",
                    City = "İstanbul",
                    Phone = "02164564437",
                    IsFree = true,
                    Price = null,
                    CreatedDate = now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                },
                new Location
                {
                    Id = 2,
                    Name = "Küçük Çamlıca",
                    Address = "Küçük Çamlıca, 34696",
                    District = "Üsküdar",
                    City = "İstanbul",
                    Phone = null,
                    IsFree = true,
                    Price = null,
                    CreatedDate = now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                },
                new Location
                {
                    Id = 3,
                    Name = "Adile Sultan Kasrı",
                    Address = "Kandilli, Vaniköy Cd No : 12, 34684",
                    District = "Üsküdar",
                    City = "İstanbul",
                    Phone = "(0216) 332 23 33",
                    IsFree = true,
                    Price = null,
                    CreatedDate = now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                },
                new Location
                {
                    Id = 4,
                    Name = "Yıldız Parkı",
                    Address = "Yıldız, Çırağan Cd., 34349",
                    District = "Beşiktaş",
                    City = "İstanbul",
                    Phone = null,
                    IsFree = true,
                    Price = null,
                    CreatedDate = now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                },
                new Location
                {
                    Id = 5,
                    Name = "Rahmi M. Koç Müzesi",
                    Address = "Piri Paşa, Rahmi M. Koç Caddesi No: 3, 34445",
                    District = "Beyoğlu",
                    City = "İstanbul",
                    Phone = "(0212) 369 66 00",
                    IsFree = false,
                    Price = 600.00m,
                    CreatedDate = now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                },
                new Location
                {
                    Id = 6,
                    Name = "Emirgan Korusu",
                    Address = "Reşitpaşa, Emirgan Sk., 34467",
                    District = "Sarıyer",
                    City = "İstanbul",
                    Phone = null,
                    IsFree = true,
                    Price = null,
                    CreatedDate = now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                }
            };

            modelBuilder.Entity<Location>().HasData(locations);
        }
    }
}