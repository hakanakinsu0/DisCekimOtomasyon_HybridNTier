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
    public static class ExtraServiceSeed
    {
        public static void SeedExtraServices(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            var services = new List<ExtraService>
            {
                new ExtraService
                {
                    Id = 1,
                    ExtraServiceCategoryId = 1,
                    Name = "30x40 Kanvas",
                    Price = 600.00m,
                    CreatedDate = now,
                    ModifiedDate = now,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                },
                new ExtraService
                {
                    Id = 2,
                    ExtraServiceCategoryId = 1,
                    Name = "50x60 Kanvas",
                    Price = 950.00m,
                    CreatedDate = now,
                    ModifiedDate = now,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                },
                new ExtraService
                {
                    Id = 3,
                    ExtraServiceCategoryId = 1,
                    Name = "50x70 Kanvas",
                    Price = 950.00m,
                    CreatedDate = now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                },
                new ExtraService
                {
                    Id = 4,
                    ExtraServiceCategoryId = 1,
                    Name = "70x100 Kanvas",
                    Price = 1200.00m,
                    CreatedDate = now,
                    ModifiedDate = now,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                },
                new ExtraService
                {
                    Id = 5,
                    ExtraServiceCategoryId = 1,
                    Name = "75x100 3 Parçalı Kanvas",
                    Price = 2200.00m,
                    CreatedDate = now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                },
                new ExtraService
                {
                    Id = 6,
                    ExtraServiceCategoryId = 1,
                    Name = "75x125 5 Parçalı Kanvas",
                    Price = 3200.00m,
                    CreatedDate = now,
                    ModifiedDate = null,
                    DeletedDate = null,
                    Status = DataStatus.Inserted
                }
            };

            modelBuilder.Entity<ExtraService>().HasData(services);
        }
    }
}
