using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.AmenityCommands;
using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Queries.AmenityQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IApplicationActor _actor;
        private readonly ActionDispatcher _dispatcher;

        public AmenityController(IApplicationActor actor, ActionDispatcher dispatcher)
        {
            _actor = actor;
            _dispatcher = dispatcher;
        }

        // GET: api/<AmenityController>
        [HttpGet]
        public IActionResult Get([FromQuery]AmenitySearch dto,
            [FromServices]IGetAmenitiesQuery getAmenitiesQuery)
        {
            return Ok(_dispatcher.DispatchQuery(getAmenitiesQuery, dto));
        }

        // GET api/<AmenityController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices]IGetSingleAmenityQuery getSingleAmenityQuery)
        {
            return Ok(_dispatcher.DispatchQuery(getSingleAmenityQuery, id));
        }

        // POST api/<AmenityController>
        [HttpPost]
        public IActionResult Post([FromBody] AmenityDto amenityDto,
            [FromServices]ICreateAmenityCommand createAmenityCommand)
        {
            _dispatcher.DispatchCommand(createAmenityCommand, amenityDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<AmenityController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
            [FromBody] AmenityDto dto, 
            [FromServices]IEditAmenityCommand editAmenityCommand)
        {
            dto.Id = id;
            _dispatcher.DispatchCommand(editAmenityCommand, dto);

            return NoContent();
        }

        // DELETE api/<AmenityController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices]IDeleteAmenityCommand deleteAmenityCommand)
        {
            _dispatcher.DispatchCommand(deleteAmenityCommand, id);
            return NoContent();
        }
    }
}
