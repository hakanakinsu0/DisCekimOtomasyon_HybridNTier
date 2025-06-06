﻿using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class ExtraServiceCategoryRepository : BaseRepository<ExtraServiceCategory>, IExtraServiceCategoryRepository
    {
        public ExtraServiceCategoryRepository(MyContext context) : base(context) { }
    }
}
