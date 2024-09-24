using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IServiceService
    {
        Task<List<Service>> GetAll();
        Task<Service> GetById(int id);
        Task Create(Service model);
        Task Update(Service model);
        Task Delete(int id);
    }
}
