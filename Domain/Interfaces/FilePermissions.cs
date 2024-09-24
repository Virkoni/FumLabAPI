using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IFilePermissionsService
    {
        Task<List<FilePermission>> GetAll();
        Task<FilePermission> GetById(int id);
        Task Create(FilePermission model);
        Task Update(FilePermission model);
        Task Delete(int id);
    }
}
