using Domain.Interfaces;
using Domain.Models;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(FumLabContext repositoryContext)
          : base(repositoryContext)
        {
        }
    }
}