using Project.BLL.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface ICustomerManager : IManager<CustomerDto, Customer>
    {
        /// <summary>
        /// Tüm müşterileri; soft-delete durumu da dahil getirir ve isteğe bağlı ad/soyad/e-posta filtresi uygular.
        /// </summary>
        /// <param name="searchTerm">Arama için kullanılacak metin; boş veya null ise filtre uygulanmaz.</param>
        /// <returns>Filtrelenmiş veya tam liste halinde <see cref="CustomerDto"/> nesnelerinin listesi.</returns>
        Task<List<CustomerDto>> GetAllWithFilterAsync(string? searchTerm);

    }
}
