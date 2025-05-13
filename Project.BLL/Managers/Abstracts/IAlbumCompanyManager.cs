using Project.BLL.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface IAlbumCompanyManager : IManager<AlbumCompanyDto, AlbumCompany>
    {
        /// <summary>
        /// Silinmemiş albüm firmalarını ve isteğe bağlı olarak ada göre filtrelenmiş sonuçları döner.
        /// </summary>
        /// <param name="searchTerm">Firma adı içinde aranacak metin (null veya boşsa tüm kayıtlar döner).</param>
        Task<List<AlbumCompanyDto>> GetAllWithFilterAsync(string? searchTerm);
    }
}
