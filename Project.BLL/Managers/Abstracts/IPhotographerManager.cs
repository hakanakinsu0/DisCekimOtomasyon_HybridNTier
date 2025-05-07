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
    /// Fotoğrafçıya dair iş kurallarını ve veri operasyonlarını tanımlar.
    /// </summary>
    public interface IPhotographerManager : IManager<PhotographerDto, Photographer>
    {
        /// <summary>
        /// Tüm fotoğrafçıları, soft-delete durumu da dahil ederek getirir ve isteğe bağlı ad-soyad filtresi uygular.
        /// </summary>
        /// <param name="searchTerm">
        /// Arama için kullanılacak ad-soyad ifadesi; boş veya null ise filtre uygulanmaz.
        /// </param>
        /// <returns>
        /// Filtrelenmiş veya tüm fotoğrafçı DTO’larını içeren liste.
        /// </returns>
        Task<List<PhotographerDto>> GetAllWithFilterAsync(string? searchTerm);
    }
}
