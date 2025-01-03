﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrdersService
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
        Task Create(Order model);
        Task Update(Order model);
        Task Delete(int id);
    }
}