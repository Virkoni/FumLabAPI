﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IPlushPartsRepository : IRepositoryBase<PlushPart>
    {
    }
}