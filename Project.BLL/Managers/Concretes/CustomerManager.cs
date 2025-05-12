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

        public async Task<List<CustomerDto>> GetAllWithFilterAsync(string? searchTerm)
        {
            // Tüm kayıtları çek
            List<Customer> entities = await _repository.GetAllAsync();

            // DTO’lara dönüştür
            List<CustomerDto> dtos = _mapper.Map<List<CustomerDto>>(entities);

            // Arama terimi varsa in-memory filtre uygula (ad/soyad/e-posta)
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                dtos = dtos.Where(c =>$"{c.BrideName} {c.GroomName} {c.LastName} {c.Email}".Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return dtos;
        }

    }
}
