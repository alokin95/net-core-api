using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer.Search;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        // GET: api/<AmenityController>
        [HttpGet]
        public IActionResult Get([FromQuery]AmenitySearch dto)
        {
            return Ok();
        }

        // GET api/<AmenityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AmenityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AmenityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AmenityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
