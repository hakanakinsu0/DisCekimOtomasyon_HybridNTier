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
    public class AlbumCompanyManager : BaseManager<AlbumCompanyDto, AlbumCompany>, IAlbumCompanyManager
    {
        public AlbumCompanyManager(IAlbumCompanyRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public async Task<List<AlbumCompanyDto>> GetAllWithFilterAsync(string? searchTerm)
        {
            // 1) Tüm varlıkları çek
            var entities = await _repository.GetAllAsync();
            // 2) DTO'lara dönüştür
            var dtos = _mapper.Map<List<AlbumCompanyDto>>(entities);
            // 3) Arama terimi varsa ada göre filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                dtos = dtos
                    .Where(ac => ac.Name
                        .Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            return dtos;
        }
    }
}
