﻿using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        public DbSet<T> Table { get;}
    }
}
