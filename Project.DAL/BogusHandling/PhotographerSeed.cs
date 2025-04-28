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
    public static class PhotographerSeed
    {
        public static void SeedPhotographers(ModelBuilder modelBuilder)
        {
            var photographers = new List<Photographer>
            {
                new Photographer
                {
                    Id = 1,
                    FirstName = "Fotografci",
                    LastName = "Bir",
                    Phone = "+905554443322",
                    Fee = 0m,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                },
                new Photographer
                {
                    Id = 2,
                    FirstName = "Fotografci",
                    LastName = "Iki",
                    Phone = "+05551112233",
                    Fee = 2000m,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                }
            };

            modelBuilder.Entity<Photographer>().HasData(photographers);
        }
    }
}
