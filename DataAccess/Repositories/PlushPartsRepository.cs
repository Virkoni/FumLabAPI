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
    public class PlushPartsRepository : RepositoryBase<PlushPart>, IPlushPartsRepository
    {
        public PlushPartsRepository(FumLabContext repositoryContext)
          : base(repositoryContext)
        {
        }
    }
}