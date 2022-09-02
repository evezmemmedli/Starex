using Starex.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        public IQueryable<T> GetAll(bool tracking);
        public IQueryable<T> GetAll(bool tracking,params string[] includes);
        public IQueryable<T> GetAll(bool tracking, Expression<Func<T, bool>> expression);
        public IQueryable<T> GetAll(bool tracking,Expression<Func<T,bool>> expression, params string[] includes);
        public IQueryable<T> Get(bool tracking);
        public IQueryable<T> Get(bool tracking, params string[] includes);
        public IQueryable<T> Get(bool tracking, Expression<Func<T, bool>> expression);
        public IQueryable<T> Get(bool tracking, Expression<Func<T, bool>> expression, params string[] includes);


    }
}
