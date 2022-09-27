using System.Linq.Expressions;
public interface IReadRepository<T> : IRepository<T> where T : class
{
    public IQueryable<T> GetAll(bool tracking);
    public IQueryable<T> GetAll(bool tracking, params string[] includes);
    public IQueryable<T> GetAll(bool tracking, Expression<Func<T, bool>> expression);
    public IQueryable<T> GetAll(bool tracking, Expression<Func<T, bool>> expression, params string[] includes);
    public IQueryable<T> Get(bool tracking);
    public IQueryable<T> Get(bool tracking, params string[] includes);
    public IQueryable<T> Get(bool tracking, Expression<Func<T, bool>> expression);
    public IQueryable<T> Get(bool tracking, Expression<Func<T, bool>> expression, params string[] includes);
}

