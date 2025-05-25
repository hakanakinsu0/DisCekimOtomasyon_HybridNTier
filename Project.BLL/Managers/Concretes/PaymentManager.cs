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
    public class PaymentManager : BaseManager<PaymentDto, Payment>, IPaymentManager
    {

        public PaymentManager(IPaymentRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            
        }

        public async Task<List<PaymentDto>> GetByReservationIdAsync(int reservationId)
        {
            // 1) Entity’leri repository üzerinden filtreleyin:
            var entities = await _repository.WhereAsync(p => p.ReservationId == reservationId);

            // 2) Mapper ile DTO’ya dönüştürün ve döndürün:
            return _mapper.Map<List<PaymentDto>>(entities);
        }
    }
}
