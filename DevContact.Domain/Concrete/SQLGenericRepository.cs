using System.Linq;
using System.Threading.Tasks;
using DevContact.Domain.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DevContact.Domain.Concrete
{
    public class SQLGenericRepository<T> : ISQLGenericRepository<T> where T : class, new()
    {
        protected SQLDBContext _context { get; set; }

        public async Task<T> GetAsync(string id)
        {
            return await _context.FindAsync<T>(id);
        }
        
        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task InsertAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(string id)
        {
            T entity= await _context.FindAsync<T>(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
