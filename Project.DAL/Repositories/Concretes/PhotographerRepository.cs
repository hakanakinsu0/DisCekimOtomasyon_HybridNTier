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
    public class PhotographerRepository : BaseRepository<Photographer>, IPhotographerRepository
    {
        public PhotographerRepository(MyContext context) : base(context) { }
    }
}
