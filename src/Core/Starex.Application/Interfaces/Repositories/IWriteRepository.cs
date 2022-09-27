public interface IWriteRepository<T> : IRepository<T> where T : class
{
    Task AddRangeAsync(List<T> entity);
    Task AddAsync(T entity);
    void Remove(T entity);
    void Update(T entity);
    Task<int> CommitAsync();
    int Commit();
}

