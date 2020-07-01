using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands.HotelCommands;
using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Hotel.Queries;
using Application.Queries;
using Application.Queries.HotelQueries;
using AutoMapper;
using DataAccess;
using Domain.Entity;
using Implementation.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly ActionDispatcher _dispatcher;
        public HotelController(ActionDispatcher actionDispatcher)
        {
            _dispatcher = actionDispatcher;
        }

        // GET: api/<HotelController>
        [HttpGet]
        public IActionResult Get([FromQuery]HotelSearch hotelSearch, [FromServices]IGetHotelsQuery getHotels)
        {
            return Ok(_dispatcher.DispatchQuery(getHotels, hotelSearch));
        }

        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices]IGetSingleHotelQuery getSingleHotelQuery)
        {
            return Ok(_dispatcher.DispatchQuery(getSingleHotelQuery, id));
        }

        // POST api/<HotelController>
        [HttpPost]
        public IActionResult Post([FromBody]CreateHotelDto createHotelDto,
            [FromServices]ICreateHotelCommand createHotelCommand)
        {
            _dispatcher.DispatchCommand(createHotelCommand, createHotelDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
            [FromBody] CreateHotelDto dto, 
            [FromServices]IEditHotelCommand editHotelCommand)
        {
            dto.Id = id;
            _dispatcher.DispatchCommand(editHotelCommand, dto);
            return NoContent();
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices]IDeleteHotelCommand deleteHotelCommand)
        {
            _dispatcher.DispatchCommand(deleteHotelCommand, id);
            return NoContent();
        }
    }
}
