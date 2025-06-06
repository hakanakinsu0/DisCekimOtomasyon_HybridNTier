﻿using Project.BLL.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface IPaymentManager : IManager<PaymentDto, Payment>
    {
        Task<List<PaymentDto>> GetByReservationIdAsync(int reservationId);

    }
}
