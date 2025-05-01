using Microsoft.Extensions.DependencyInjection;
using Project.BLL.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DependencyResolvers
{
    /// <summary>
    /// AutoMapper'ın DI container'a eklenmesini sağlayan resolver sınıfı.
    /// Nesneler arası dönüşümleri kolaylaştıran AutoMapper konfigürasyonunu sağlar.
    /// </summary>
    public static class MapperResolver
    {
        /// <summary>
        /// AutoMapper'ı servis koleksiyonuna ekler.
        /// </summary>
        /// <param name="services">Bağımlılık enjeksiyonuna eklenecek servis koleksiyonu.</param>
        public static void AddMapperService(this IServiceCollection services)
        {
            // MappingProfile sınıfını kullanarak tüm DTO ↔ Entity dönüşümlerini kaydeder.
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
