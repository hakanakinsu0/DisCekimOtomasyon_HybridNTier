using Project.BLL.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    /// <summary>
    /// Mekanlara dair iş kurallarını ve veri operasyonlarını tanımlar.
    /// </summary>
    public interface ILocationManager : IManager<LocationDto, Location>
    {
        /// <summary>
        /// Tüm mekanları getirir; soft-delete durumu da dahil ederek,
        /// isteğe bağlı ad-adres-ilçe-şehir filtresi uygular.
        /// </summary>
        /// <param name="searchTerm">
        /// Arama için kullanılacak terim. İsim, adres, ilçe veya şehir içeriyorsa filtreler.
        /// </param>
        /// <returns>Filtrelenmiş veya tüm <see cref="LocationDto"/> listesi.</returns>
        Task<List<LocationDto>> GetAllWithFilterAsync(string? searchTerm);
    }
}
