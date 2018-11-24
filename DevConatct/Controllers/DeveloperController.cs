using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevConatct.Infrastructure;
using DevConatct.Model;
using DevContact.Domain.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevConatct.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private IDevContactRepository _devRepo = null;
       
        public DeveloperController(IDevContactRepository repo)
        {
            _devRepo = repo;
            
        }

        // GET api/Developer/Get
        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<DevContact.Domain.Entities.DevContact>> Get()
        {
            return _devRepo.Query().ToList();

        }
        // PUT api/Developer/Add
        [HttpPost("Add/")]
        public void Post([FromBody]DevContact.Domain.Entities.DevContact value)
        {
            _devRepo.InsertAsync(value);
        }
        // GET api/Developer/GetCategory/id
        [HttpGet("GetCat/{id}")]
        public async Task<DevContact.Domain.Entities.DevContact> GetCategory(int id)
        {
            return await _devRepo.GetCatAsync(id) ?? new DevContact.Domain.Entities.DevContact();
 
        }
        // GET api/Developer/Get/id
       
        [HttpGet("Get/{id}")]
        public async Task<DevContact.Domain.Entities.DevContact> Get(string id)
        {
            return await _devRepo.GetAsync(id) ?? new DevContact.Domain.Entities.DevContact();


        }

        // PUT api/Developer/value
        [HttpPut("Update/{id}")]
        public void Put([FromBody]DevContact.Domain.Entities.DevContact value)
        {
            _devRepo.UpdateAsync(value);
        }

        // DELETE api/Developer/23243423
        [HttpDelete("Remove/{id}")]
        public void Delete(string id)
        {
            _devRepo.RemoveAsync(id);
        }
    }
}
