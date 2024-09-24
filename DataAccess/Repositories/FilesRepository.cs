﻿using System;
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
    public class FilesRepository : RepositoryBase<Domain.Models.File>, IFilesRepository
    {
        public FilesRepository(PetshopContext repositoryContext)
          : base(repositoryContext)
        {
        }
    }
}