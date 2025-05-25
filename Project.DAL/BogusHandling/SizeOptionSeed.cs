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
    public static class SizeOptionSeed
    {
        public static void SeedSizeOptions(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            var options = new List<SizeOption>
            {
                new SizeOption { Id = 1,  ServiceCategoryId = 1,  Dimension = "25x70 New Line",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 2,  ServiceCategoryId = 1,  Dimension = "30x60 New Line",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 3,  ServiceCategoryId = 1,  Dimension = "30x80 New Line",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 4,  ServiceCategoryId = 2,  Dimension = "25x70 Standart",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 5,  ServiceCategoryId = 2,  Dimension = "30x50 Standart",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 6,  ServiceCategoryId = 2,  Dimension = "25x60 Standart",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 7,  ServiceCategoryId = 2,  Dimension = "30x60 Standart",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 8,  ServiceCategoryId = 2,  Dimension = "30x80 Standart",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 9,  ServiceCategoryId = 3,  Dimension = "25x60 Kampanya",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 10, ServiceCategoryId = 3,  Dimension = "25x50 Kampanya",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 11, ServiceCategoryId = 3,  Dimension = "25x70 Kampanya",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 12, ServiceCategoryId = 3,  Dimension = "30x50 Kampanya",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 13, ServiceCategoryId = 3,  Dimension = "30x60 Kampanya",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 14, ServiceCategoryId = 3,  Dimension = "30x76 Kampanya",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 15, ServiceCategoryId = 3,  Dimension = "30x80 Kampanya",    CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 16, ServiceCategoryId = 4,  Dimension = "25x70 Çizgi Avantaj", CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 17, ServiceCategoryId = 4,  Dimension = "30x60 Çizgi Avantaj", CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 18, ServiceCategoryId = 4,  Dimension = "30x70 Çizgi Avantaj", CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 19, ServiceCategoryId = 4,  Dimension = "25x50 Çizgi Avantaj", CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 20, ServiceCategoryId = 4,  Dimension = "25x60 Çizgi Avantaj", CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted },
                new SizeOption { Id = 21, ServiceCategoryId = 4,  Dimension = "30x50 Çizgi Avantaj", CreatedDate = now, ModifiedDate = null, DeletedDate = null, Status = DataStatus.Inserted }
            };

            modelBuilder.Entity<SizeOption>().HasData(options);
        }
    }
}