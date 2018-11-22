using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevConatct.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DevConatct.Data
{
    public class DbContext
    {
        private readonly IMongoDatabase _database = null;

        public DbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoCollection<DevContact> DevContacts => _database.GetCollection<DevContact>("DevContact");
    }
}
