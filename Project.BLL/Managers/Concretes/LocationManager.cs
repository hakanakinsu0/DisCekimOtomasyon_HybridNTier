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
    public class LocationManager : BaseManager<LocationDto, Location>, ILocationManager
    {
        public LocationManager(ILocationRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        /// <summary>
        /// Tüm mekanları getirir; silinmişleri de dahil eder ve isteğe bağlı ad-adres-ilçe-şehir filtresi uygular.
        /// </summary>
        public async Task<List<LocationDto>> GetAllWithFilterAsync(string? searchTerm)
        {
            // Tüm kayıtları çek
            List<Location> entities = await _repository.GetAllAsync();

            // DTO'lara dönüştür
            List<LocationDto> dtos = _mapper.Map<List<LocationDto>>(entities);

            // Arama terimi varsa in-memory filtre uygula
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                dtos = dtos.Where(l =>
                    {
                        var haystack = $"{l.Name} {l.Address} {l.District} {l.City}";
                        return haystack.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
                    }).ToList();
            }

            return dtos;
        }
    }
}
