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
    public class SuppliersRepository : RepositoryBase<Supplier>, ISuppliersRepository
    {
        public SuppliersRepository(PetshopContext repositoryContext)
          : base(repositoryContext)
        {
        }
    }
}
