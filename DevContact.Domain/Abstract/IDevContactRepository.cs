using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevContact.Domain.Abstract
{
    public interface IDevContactRepository : ISQLGenericRepository<Entities.DevContact>
    {
        Task<Entities.DevContact> GetCatAsync(int id);
    }
}
