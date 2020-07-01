using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.RoomCommands;
using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Queries.RoomQueries;
using Implementation.Commands.RoomCommands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly ActionDispatcher _dispatcher;

        public RoomController(ActionDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        // GET: api/<RoomController>
        [HttpGet]
        public IActionResult Get([FromQuery] RoomSearch search,
            [FromServices]IGetRoomsQuery getRoomsQuery)
        {
            return Ok(_dispatcher.DispatchQuery(getRoomsQuery, search));
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices]IGetSingleRoomQuery getSingleRoomQuery)
        {
            return Ok(_dispatcher.DispatchQuery(getSingleRoomQuery, id));
        }

        // POST api/<RoomController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRoomDto dto,
            [FromServices]ICreateRoomCommand createRoomCommand)
        {
            _dispatcher.DispatchCommand(createRoomCommand, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
            [FromBody]CreateRoomDto dto,
            [FromServices]IEditRoomCommand editRoomCommand)
        {
            dto.Id = id;
            _dispatcher.DispatchCommand(editRoomCommand, dto);
            return NoContent();
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices]IDeleteRoomCommand deleteRoomCommand)
        {
            _dispatcher.DispatchCommand(deleteRoomCommand, id);
            return NoContent();
        }
    }
}
