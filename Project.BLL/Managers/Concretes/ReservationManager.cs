using AutoMapper;
using Project.BLL.DtoClasses;
using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class ReservationManager : BaseManager<ReservationDto, Reservation>, IReservationManager
    {
        public ReservationManager(IReservationRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public async Task<ReservationDto> CreateAsync(ReservationDto dto)
        {
            // DTO → Entity
            var entity = _mapper.Map<Reservation>(dto);

            // Repository üzerinden ekle
            await _repository.CreateAsync(entity);

            // EF Core, CreateAsync sonrası entity.Id’yi doldurur
            dto.Id = entity.Id;

            return dto;
        }
    }
}
