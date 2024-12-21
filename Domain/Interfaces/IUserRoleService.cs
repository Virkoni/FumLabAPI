using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRoleService
    {
        Task<List<UserRole>> GetAll();
        Task<UserRole> GetById(int id);
        Task Create(UserRole model);
        Task Update(UserRole model);
        Task Delete(int id);
    }
}