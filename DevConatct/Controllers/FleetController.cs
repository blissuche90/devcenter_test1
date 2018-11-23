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
    public class FleetController : ControllerBase
    {
        private List<Car> defaultlist = null;
        public FleetController()
        {
            defaultlist = new List<Car>{
                new Car
                {
                    Ownername = "Adedeji Obi",
                    Registration = "AB-4568-OKJ",
                    Id = "5675ff78t757577",
                    Type = 1
                },
                new Car
                {
                    Ownername = "Curator Uche",
                    Registration  = "LG-6765-IKJ",
                    Id = "54647478t757577",
                    Type = 2
                }
            };
        }
        [NoCache]
        [HttpGet]
        public List<Car> Get()
        {           
            return defaultlist.ToList();
        }
        // GET api/Fleet/GetCategory/id
        // GET api/Fleet/5
        [HttpGet("{id}")]
        public async Task<Car> Get(string id)
        {
            return (from c in defaultlist where c.Id == id select c).FirstOrDefault() ?? new Car();


        }

        // PUT api/Fleet/value
        [HttpPut("{id}")]
        public void Put([FromBody]string value)
        {
            //_devRepo.Update(()value);
        }

        // DELETE api/Fleet/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            //_devRepo.Remove(id);
        }
    }
}