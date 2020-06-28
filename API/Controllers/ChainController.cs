using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DataTransfer.Search;
using Application.Queries.Chain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChainController : ControllerBase
    {
        private readonly ActionDispatcher _dispatcher;
        public ChainController(ActionDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        // GET: api/<ChainController>
        [HttpGet]
        public IActionResult Get([FromQuery]ChainSearch chainSearch, 
            [FromServices]IGetChainsQuery getChainsQuery)
        {
            return Ok(_dispatcher.DispatchQuery(getChainsQuery, chainSearch));
        }

        // GET api/<ChainController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChainController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChainController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChainController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
