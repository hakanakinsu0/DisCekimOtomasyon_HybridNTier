using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AlbumCompanyRepository : BaseRepository<AlbumCompany>, IAlbumCompanyRepository
    {
        public AlbumCompanyRepository(MyContext context) : base(context) { }
    }
}
