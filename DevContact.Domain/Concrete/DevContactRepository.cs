using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevContact.Domain.Abstract;

namespace DevContact.Domain.Concrete
{

    public class DevContactRepository : SQLGenericRepository<Entities.DevContact>, IDevContactRepository
    {
        public DevContactRepository(SQLDBContext ctx)
        {
            _context = ctx;

        }
        public async Task<Entities.DevContact> GetCatAsync(int id)
        {
            var model = from c in _context.DevContacts where c.Type == id select c;
            return model.FirstOrDefault();
        }
    }

}
