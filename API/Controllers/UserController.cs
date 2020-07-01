using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.UserCommands;
using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Queries.UserQueries;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ActionDispatcher _dispatcher;
        public UserController(ActionDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }


        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search,
            [FromServices]IGetUsersQuery getUsersQuery)
        {
            return Ok(_dispatcher.DispatchQuery(getUsersQuery, search));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices]IGetSingleUserQuery getSingleUserQuery)
        {
            return Ok(_dispatcher.DispatchQuery(getSingleUserQuery, id));
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody]UserDto dto,
            [FromServices]ICreateUserCommand createUserCommand)
        {
            _dispatcher.DispatchCommand(createUserCommand, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
            [FromBody] UserDto dto,
            [FromServices]IEditUserCommand editUserCommand)
        {
            dto.Id = id;
            _dispatcher.DispatchCommand(editUserCommand, dto);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices]IDeleteUserCommand deleteUserCommand)
        {
            _dispatcher.DispatchCommand(deleteUserCommand, id);
            return NoContent();
        }
    }
}
