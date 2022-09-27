using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starex.Persistence.Context;
using Starex.Domain.Entities.Base;

namespace Starex.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly StarexDbContext _context;
        public Repository(StarexDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
    }
}
