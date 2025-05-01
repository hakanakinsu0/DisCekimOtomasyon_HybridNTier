using AutoMapper;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class CustomerManager : BaseManager<CustomerDto, Customer>, ICustomerManager
    {
        public CustomerManager(ICustomerRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
