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
        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<DevContact>> Get()
        {
            //return await _devRepo.GetAll();
            return null;
        }
    }
}