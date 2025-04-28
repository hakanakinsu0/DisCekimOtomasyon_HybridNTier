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
    public class SizeOptionRepository : BaseRepository<SizeOption>, ISizeOptionRepository
    {
        public SizeOptionRepository(MyContext context) : base(context) { }
    }
}
