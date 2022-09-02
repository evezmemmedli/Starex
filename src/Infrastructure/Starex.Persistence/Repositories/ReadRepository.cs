using Microsoft.EntityFrameworkCore;
using Starex.Application.Repositories;
using Starex.Domain.Entities.Base;
using Starex.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly StarexDbContext _context;
        public ReadRepository(StarexDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> Get(bool tracking)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTrackingWithIdentityResolution();
            return query;
        }
   

        public IQueryable<T> Get(bool tracking, params string[] includes)
        {
            var query = GetAll(tracking);

            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public IQueryable<T> Get(bool tracking, Expression<Func<T, bool>> expression)
        {
            var query = Table.Where(expression);

            if (!tracking)
                query = query.AsNoTrackingWithIdentityResolution();

            return query;
        }

        public IQueryable<T> Get(bool tracking, Expression<Func<T, bool>> expression, params string[] includes)
        {
            var query = GetAll(tracking, expression);
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public IQueryable<T> GetAll(bool tracking)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTrackingWithIdentityResolution();

            return query;
        }

        public IQueryable<T> GetAll(bool tracking, params string[] includes)
        {
            var query = GetAll(tracking);

            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
        public IQueryable<T> GetAll(bool tracking, Expression<Func<T, bool>> expression)
        {
            var query = Table.Where(expression);

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }


        public IQueryable<T> GetAll(bool tracking, Expression<Func<T,bool>> expression, params string[] includes)
        {
           var query= GetAll(tracking, expression);

            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        
    }
}
