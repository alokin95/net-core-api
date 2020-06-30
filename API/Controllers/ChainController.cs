using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.ChainCommands;
using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Queries.ChainQueries;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Get(int id,
            [FromServices]IGetSingleChainQuery getSingleChainQuery)
        {
            return Ok(_dispatcher.DispatchQuery(getSingleChainQuery, id));
        }

        // POST api/<ChainController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateChainDto createChainDto, [FromServices]ICreateChainCommand createChainCommand)
        {
            _dispatcher.DispatchCommand(createChainCommand, createChainDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ChainController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
            [FromBody] CreateChainDto chainDto,
            [FromServices] IEditChainCommand editChainCommand)
        {
            chainDto.Id = id;
            _dispatcher.DispatchCommand(editChainCommand, chainDto);
            return NoContent();
        }

        // DELETE api/<ChainController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices]IDeleteChainCommand deleteChainCommand)
        {
            _dispatcher.DispatchCommand(deleteChainCommand, id);
            return NoContent();
        }
    }
}
