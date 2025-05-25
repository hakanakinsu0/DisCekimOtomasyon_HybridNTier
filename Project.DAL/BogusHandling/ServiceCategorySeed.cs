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
    public static class ServiceCategorySeed
    {
        public static void SeedServiceCategories(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            var collections = new List<ServiceCategory>
            {
                new ServiceCategory
                {
                    Id              = 1,
                    AlbumCompanyId  = 1,
                    Name            = "New Line Collection",
                    CreatedDate     = now,
                    ModifiedDate    = null,
                    DeletedDate     = null,
                    Status          = DataStatus.Inserted
                },
                new ServiceCategory
                {
                    Id              = 2,
                    AlbumCompanyId  = 1,
                    Name            = "Standart Seri",
                    CreatedDate     = now,
                    ModifiedDate    = null,
                    DeletedDate     = null,
                    Status          = DataStatus.Inserted
                },
                new ServiceCategory
                {
                    Id              = 3,
                    AlbumCompanyId  = 1,
                    Name            = "Kampanya Seri",
                    CreatedDate     = now,
                    ModifiedDate    = null,
                    DeletedDate     = null,
                    Status          = DataStatus.Inserted
                },
                new ServiceCategory
                {
                    Id              = 4,
                    AlbumCompanyId  = 1,
                    Name            = "Çizgi Avantaj Seri",
                    CreatedDate     = now,
                    ModifiedDate    = null,
                    DeletedDate     = null,
                    Status          = DataStatus.Inserted
                }
            };

            modelBuilder.Entity<ServiceCategory>().HasData(collections);
        }
    }
}