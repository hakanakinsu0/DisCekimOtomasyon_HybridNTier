using Microsoft.Extensions.DependencyInjection;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DependencyResolvers
{
    /// <summary>
    /// Tüm manager sınıflarının Dependency Injection'a eklenmesini sağlayan resolver sınıfı.
    /// İş mantığı (Business Logic Layer - BLL) bileşenlerini DI sistemine dahil eder.
    /// </summary>
    public static class ManagerResolver
    {
        /// <summary>
        /// Manager servislerini DI container'a ekler.
        /// </summary>
        /// <param name="services">Bağımlılık enjeksiyonuna eklenecek servis koleksiyonu.</param>
        public static void AddManagerService(this IServiceCollection services)
        {
            // BLL Manager Katmanı Bağımlılıkları
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IAlbumCompanyManager, AlbumCompanyManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IExtraServiceCategoryManager, ExtraServiceCategoryManager>();
            services.AddScoped<IExtraServiceManager, ExtraServiceManager>();
            services.AddScoped<ILocationManager, LocationManager>();
            services.AddScoped<IPackageOptionManager, PackageOptionManager>();
            services.AddScoped<IPackageExtraManager, PackageExtraManager>();
            services.AddScoped<IPaymentManager, PaymentManager>();
            services.AddScoped<IPhotographerManager, PhotographerManager>();
            services.AddScoped<IReservationManager, ReservationManager>();
            services.AddScoped<IReservationExtraManager, ReservationExtraManager>();
            services.AddScoped<IServiceCategoryManager, ServiceCategoryManager>();
            services.AddScoped<ISizeOptionManager, SizeOptionManager>();
        }
    }
}
