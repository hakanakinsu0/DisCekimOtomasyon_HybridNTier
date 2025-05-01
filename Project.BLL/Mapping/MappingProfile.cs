using AutoMapper;
using Project.BLL.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Mapping
{
    /// <summary>
    /// AutoMapper konfigürasyonlarının tanımlandığı sınıftır.
    /// Entity sınıfları ile DTO sınıfları arasındaki dönüşümleri tanımlar.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity ↔ DTO maplemeleri
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AlbumCompany, AlbumCompanyDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<ExtraServiceCategory, ExtraServiceCategoryDto>().ReverseMap();
            CreateMap<ExtraService, ExtraServiceDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<PackageOption, PackageOptionDto>().ReverseMap();
            CreateMap<PackageExtra, PackageExtraDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Photographer, PhotographerDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<ReservationExtra, ReservationExtraDto>().ReverseMap();
            CreateMap<ServiceCategory, ServiceCategoryDto>().ReverseMap();
            CreateMap<SizeOption, SizeOptionDto>().ReverseMap();
        }
    }
}
