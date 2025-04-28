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
    public static class AlbumCompanySeed
    {
        public static void SeedAlbumCompanies(ModelBuilder modelBuilder)
        {
            var companies = new List<AlbumCompany>
            {
                new AlbumCompany
                {
                    Id = 1,
                    Name = "ÇİZGİ ALBÜM FOTOĞRAFÇILIK",
                    Address = "Karayolları Mah. 559 Sk. No:18/1 G.O.PAŞA / İSTANBUL / TÜRKİYE",
                    Phone = "+02125387994",
                    Email = "cizgialbum@gmail.com",
                    ContactPersonName = "Test",
                    ContactPersonPhone = "+905359750193",
                    ContactPersonEmail = "cizgialbum@gmail.com",
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                }
            };

            modelBuilder.Entity<AlbumCompany>().HasData(companies);
        }
    }
}
