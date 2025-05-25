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
    public static class ExtraServiceCategorySeed
    {
        public static void SeedExtraServiceCategories(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            var categories = new List<ExtraServiceCategory>
            {
                new ExtraServiceCategory
                {
                    Id = 1,
                    Name = "Kanvas",
                    CreatedDate = now,
                    Status = DataStatus.Inserted
                },
                new ExtraServiceCategory
                {
                    Id = 2,
                    Name = "Poster",
                    CreatedDate = now,
                    Status = DataStatus.Inserted
                },
                new ExtraServiceCategory
                {
                    Id = 3,
                    Name = "Saat",
                    CreatedDate = now,
                    Status = DataStatus.Inserted
                },
                new ExtraServiceCategory
                {
                    Id = 4,
                    Name = "Lüx Çerçeve",
                    CreatedDate = now,
                    Status = DataStatus.Inserted
                },
                new ExtraServiceCategory
                {
                    Id = 5,
                    Name = "Lake Çerçeve",
                    CreatedDate = now,
                    Status = DataStatus.Inserted
                },
                new ExtraServiceCategory
                {
                    Id = 6,
                    Name = "Oval Çerçeve",
                    CreatedDate = now,
                    Status = DataStatus.Inserted
                }
            };

            modelBuilder.Entity<ExtraServiceCategory>().HasData(categories);
        }
    }
}
