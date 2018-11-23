using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevConatct.Infrastructure;
using DevConatct.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DevConatct.Data
{
    public class DevContactRepository : IDevContactRepository
    {
        private readonly DbContext _context = null;

        public DevContactRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<IEnumerable<DevContact>> GetAll()
        {
            try
            {
                return await _context.DevContacts.Find(_ => true).ToListAsync();

            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // query after Id or InternalId (BSonId value)
        //
        public async Task<DevContact> Get(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.DevContacts
                                .Find(contact => contact.Id == id || contact.InternalId == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<DevContact> GetCatgory(int id)
        {
            try
            {               
                return await _context.DevContacts
                    .Find(note => note.Type == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Try to convert the Id to a BSonId value
        private ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task Add(DevContact item)
        {
            try
            {
                await _context.DevContacts.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.DevContacts.DeleteOneAsync(
                     Builders<DevContact>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Update(DevContact item)
        {
            var filter = Builders<DevContact>.Filter.Eq(s => s.Id, item.Id);
            var update = Builders<DevContact>.Update
                            .Set(s => s.Fullname, item.Fullname)
                            .CurrentDate(s => s.ModificationDateTime);

            try
            {
                UpdateResult actionResult = await _context.DevContacts.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
      
        public async Task<bool> RemoveAll()
        {
            try
            {
                DeleteResult actionResult = await _context.DevContacts.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // it creates a sample compound index (first using UserId, and then Body)
        // 
        // MongoDb automatically detects if the index already exists - in this case it just returns the index details
        public async Task<string> CreateIndex()
        {
            try
            {
                IndexKeysDefinition<DevContact> keys = Builders<DevContact>
                                                    .IndexKeys
                                                    .Ascending(item => item.Id)
                                                    .Ascending(item => item.Email);

                return await _context.DevContacts
                                .Indexes.CreateOneAsync(new CreateIndexModel<DevContact>(keys));
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
