using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IInventoryService
    {
        Task<List<Inventory>> GetAll();
        Task<Inventory> GetById(int id);
        Task Create(Inventory model);
        Task Update(Inventory model);
        Task Delete(int id);
    }
}
