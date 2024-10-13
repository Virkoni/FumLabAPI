using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CustomPlushOrderPartsRepository : RepositoryBase<CustomPlushOrderPart>, ICustomPlushOrderPartsRepository
    {
        public CustomPlushOrderPartsRepository(FumLabContext repositoryContext)
          : base(repositoryContext)
        {
        }
    }
}
