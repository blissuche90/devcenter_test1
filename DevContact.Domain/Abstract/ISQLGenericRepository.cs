using System.Linq;
using System.Threading.Tasks;

namespace DevContact.Domain.Abstract
{
    public interface ISQLGenericRepository<T>
    {
        Task<T> GetAsync(string id);

        IQueryable<T> Query();

        Task InsertAsync(T entity);

        Task RemoveAsync(string id);

        Task UpdateAsync(T entity);
    }
}
