using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevConatct.Infrastructure;
using DevConatct.Model;
using Microsoft.AspNetCore.Mvc;

namespace DevConatct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private IDevContactRepository _devRepo = null;
        public DeveloperController(IDevContactRepository repo)
        {
            _devRepo = repo;
        }

        // GET api/values
        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<DevContact>> Get()
        {
            return await _devRepo.GetAll();
            
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public async Task<DevContact> Get(string id)
        {
            return await _devRepo.Get(id) ?? new DevContact();
        
            
        }
    
        // PUT api/notes/5
        [HttpPut("{id}")]
        public void Put( [FromBody]string value)
        {
            //_devRepo.Update(()value);
        }

        // DELETE api/notes/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _devRepo.Remove(id);
        }
    }
}
