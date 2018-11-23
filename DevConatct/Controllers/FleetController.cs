using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevConatct.Infrastructure;
using DevConatct.Model;
using DevContact.Domain.Abstract;
using DevContact.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevConatct.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FleetController : ControllerBase
    {
        private ICarRepository _carRepo = null;

        public FleetController(ICarRepository repo)
        {
            this._carRepo = repo;
        }

        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<Car>> Get()
        {
            return _carRepo.Query().ToList();

        }

        // GET api/Fleet/GetCategory/id       
        [HttpGet("Get/{id}")]
        public async Task<Car> Get(string id)
        {
            return await _carRepo.GetAsync(id) ?? new Car();

        }

        // GET api/Fleet/GetCategory/id       
        [HttpGet("GetCat/{id}")]
        public async Task<Car> Get(int id)
        {
            return await _carRepo.GetCatAsync(id) ?? new DevContact.Domain.Entities.Car();

        }

        // PUT api/Fleet/value
        [HttpPut("Update/{id}")]
        public void Put([FromBody] Car value)
        {
            _carRepo.UpdateAsync(value);
        }

        // DELETE api/Fleet/23243423
        [HttpDelete("Remove/{id}")]
        public void Delete(string id)
        {
            _carRepo.RemoveAsync(id);
        }
    }
}