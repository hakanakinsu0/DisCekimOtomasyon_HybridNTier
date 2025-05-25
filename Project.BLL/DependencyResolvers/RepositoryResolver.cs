using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DependencyResolvers
{
    public static class RepositoryResolver
    {
        public static void AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IPhotographerRepository, PhotographerRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IAlbumCompanyRepository, AlbumCompanyRepository>();
            services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
            services.AddScoped<ISizeOptionRepository, SizeOptionRepository>();
            services.AddScoped<IPackageOptionRepository, PackageOptionRepository>();
            services.AddScoped<IExtraServiceCategoryRepository, ExtraServiceCategoryRepository>();
            services.AddScoped<IExtraServiceRepository, ExtraServiceRepository>();
            services.AddScoped<IReservationExtraRepository, ReservationExtraRepository>();
        }
    }
}
