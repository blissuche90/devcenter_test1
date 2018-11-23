using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevConatct.Model;

namespace DevConatct.Infrastructure
{
    public interface IDevContactRepository
    {
        Task<IEnumerable<DevContact>> GetAll();

        Task<DevContact> Get(string id);

        Task<DevContact> GetCatgory(int id);
        // query after multiple parameters
        //Task<IEnumerable<T>> GetNote(string bodyText, DateTime updatedFrom, long headerSizeLimit);

        // add new note document
        Task Add(DevContact item);

        // remove a single document / note
        Task<bool> Remove(string id);

        // update just a single document / note
        Task<bool> Update( DevContact item);     

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAll();

        // creates a sample index
        Task<string> CreateIndex();
    }
}
