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
        private List<DevContact> defaultdata = null;
        public DeveloperController(IDevContactRepository repo)
        {
            _devRepo = repo;
            defaultdata = new List<DevContact>
            {
                new DevContact
                {
                    Fullname = "Adedeji Obi",
                    Email = "uchenna@gmail.com",
                    Address = "7 Opebi Ikeja",
                    Id = "5675ff78t757577",
                    Type = 1
                },
                new DevContact
                {
                    Fullname = "Curator Uche",
                    Email = "uchenna@gmail.com",
                    Address = "7 Opebi Ikeja",
                    Id = "54647478t757577",
                    Type = 2
                }
            };
        }

        // GET api/Developer/Get
        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<DevContact>> Get()
        {
            return await _devRepo.GetAll();
            
        }

        // GET api/Developer/GetCategory/id
        [HttpGet("{id}")]
        public async Task<DevContact> GetCategory(int id)
        {
            return await _devRepo.GetCatgory(id) ?? new DevContact();
        
            
        }
        // GET api/Developer/5
        [HttpGet("{id}")]
        public async Task<DevContact> Get(string id)
        {
            return await _devRepo.Get(id) ?? new DevContact();


        }

        // PUT api/Developer/value
        [HttpPut("{id}")]
        public void Put( [FromBody]string value)
        {
            //_devRepo.Update(()value);
        }

        // DELETE api/Developer/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _devRepo.Remove(id);
        }
    }
}
