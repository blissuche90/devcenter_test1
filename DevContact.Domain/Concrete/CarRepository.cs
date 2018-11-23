using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevContact.Domain.Abstract;
using DevContact.Domain.Entities;

namespace DevContact.Domain.Concrete
{
    public class CarRepository : SQLGenericRepository<Car>, ICarRepository
    {
        public CarRepository(SQLDBContext ctx)
        {
            _context = ctx;

        }
        public async Task<Car> GetCatAsync(int id)
        {
            var model = from c in _context.Cars where c.Type == id select c;
            return model.FirstOrDefault();
        }
    }
}
