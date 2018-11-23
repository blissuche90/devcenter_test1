using DevContact.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevContact.Domain.Concrete
{
    public class SQLDBContext:DbContext
    {
        public SQLDBContext(DbContextOptions options)
            : base(options) { }
        public DbSet<Entities.DevContact> DevContacts { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
