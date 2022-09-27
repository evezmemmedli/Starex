using Microsoft.EntityFrameworkCore;
using Starex.Persistence.Context;

namespace Starex.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T>
        where T : class
    {
        private readonly StarexDbContext _context;
        public WriteRepository(StarexDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
          
        }

        public async Task AddRangeAsync(List<T> entity)
        {
            await Table.AddRangeAsync(entity);
            
       
        }

        public int Commit() => _context.SaveChanges();

        public async Task<int> CommitAsync() =>await _context.SaveChangesAsync();
       

        public  void Remove(T entity)
        {
            Table.Remove(entity);
        
        }
        public void Update(T entity)
        {
            Table.Update(entity);
            
        }
    }
}
