using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
public interface IRepository<T> where T : class
{
    public DbSet<T> Table { get; }
}

