using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevContact.Domain.Entities;

namespace DevContact.Domain.Abstract
{
    public interface ICarRepository : ISQLGenericRepository<Car>
    {
        Task<Car> GetCatAsync(int id);
    }
}
