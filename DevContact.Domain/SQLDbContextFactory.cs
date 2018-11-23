using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DevContact.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevContact.Domain
{
    
        public class SQLDbContextFactory : IDesignTimeDbContextFactory<SQLDBContext>
        {
            public SQLDBContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<SQLDBContext>();
#if DEBUG
                builder.UseSqlServer("Server=XXXXXXXXX\\SQLEXPRESS;Database=DaveCentreDb;Trusted_Connection=True;",
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(SQLDBContext).GetTypeInfo().Assembly
                        .GetName().Name));
#else
            builder.UseSqlServer("",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(PluralPayDbContext).GetTypeInfo().Assembly.GetName().Name);
#endif
                return new SQLDBContext(builder.Options);
            }
        }
    
}
