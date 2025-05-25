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
            var now = DateTime.Now;
            var photographers = new List<Photographer>
            {
                new Photographer
                {
                    Id = 1,
                    FirstName     = "Hakan",
                    LastName      = "Akınsu",
                    Phone         = "05538971905",
                    Fee           = 2000.00m,
                    CreatedDate   = now,
                    ModifiedDate  = now,
                    DeletedDate   = null,
                    Status        = DataStatus.Updated
                },
                new Photographer
                {
                    Id = 2,
                    FirstName     = "Mustafa Osman",
                    LastName      = "Kaya",
                    Phone         = "05538275858",
                    Fee           = 5000.00m,
                    CreatedDate   = now,
                    ModifiedDate  = null,
                    DeletedDate   = null,
                    Status        = DataStatus.Inserted
                }
            };

            modelBuilder.Entity<Photographer>().HasData(photographers);
        }
    }
}
