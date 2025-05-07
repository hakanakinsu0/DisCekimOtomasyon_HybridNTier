using AutoMapper;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    /// <summary>
    /// Fotoğrafçı verilerine yönelik BLL işlemlerini yürütür.
    /// BaseManager üzerinden CRUD ve temel iş kurallarını devralır, ek olarak filtreleme yeteneği sağlar.
    /// </summary>
    public class PhotographerManager : BaseManager<PhotographerDto, Photographer>, IPhotographerManager
    {
        public PhotographerManager(IPhotographerRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        /// <summary>
        /// Tüm fotoğrafçıları getirir; silinmiş durumunu da dahil ederek, isteğe bağlı ad-soyad filtresi uygular.
        /// </summary>
        /// <param name="searchTerm">
        /// Ad ve soyadı birleştirerek arama yapmak için kullanılacak terim. 
        /// Boş veya null ise hiçbir filtre uygulanmaz.
        /// </param>
        /// <returns>Filtrelenmiş veya tam liste halinde <see cref="PhotographerDto"/> nesnelerinin listesi.</returns>
        public async Task<List<PhotographerDto>> GetAllWithFilterAsync(string? searchTerm)
        {
            // Tüm kayıtları çek
            List<Photographer> entities = await _repository.GetAllAsync();

            // DTO'ya dönüştür
            List<PhotographerDto> dtos = _mapper.Map<List<PhotographerDto>>(entities);

            // Arama terimi varsa in‐memory filtre uygula (ad + soyad)
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                dtos = dtos.Where(p =>
                    {
                        string? fullName = $"{p.FirstName} {p.LastName}";
                        return fullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
                    }).ToList();
            }

            return dtos;
        }

    }
}
