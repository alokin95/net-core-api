using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DataTransfer;
using Application.DataTransfer.Search;
using Application.Hotel.Queries;
using Application.Queries;
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
        private readonly ActionDispatcher actionDispatcher;
        public HotelController(ActionDispatcher actionDispatcher)
        {
            this.actionDispatcher = actionDispatcher;
        }

        // GET: api/<HotelController>
        [HttpGet]
        public IActionResult Get([FromQuery]HotelSearch hotelSearch, [FromServices]IGetHotelsQuery getHotels)
        {
            return Ok(actionDispatcher.DispatchQuery(getHotels, hotelSearch));
            /*try
            {
                var hotelsQuery = _dbContext.Hotels.AsQueryable();

                if (dto.Country != null)
                {
                    hotelsQuery = hotelsQuery.Where(h => h.Location.Country.ToLower().Contains(dto.Country.ToLower()));
                }

                if (dto.City != null)
                {
                    hotelsQuery = hotelsQuery.Where(h => h.Location.City.ToLower().Contains(dto.Country.ToLower()));
                }

                if (dto.Address != null)
                {
                    hotelsQuery = hotelsQuery.Where(h => h.Location.Address.ToLower().Contains(dto.Address.ToLower()));
                }

                if (dto.Name != null)
                {
                    hotelsQuery = hotelsQuery.Where(h => h.Name.ToLower().Contains(dto.Name.ToLower()));
                }

                if (dto.PostalCode.ToString() != null)
                {
                    hotelsQuery = hotelsQuery.Where(h => h.Location.PostalCode == dto.PostalCode);
                }

                var response = _mapper.Map<List<HotelDto>>(hotelsQuery.ToList());

                return Ok(response);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }*/
        }

        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return null;
        }

        // POST api/<HotelController>
        [HttpPost]
        public IActionResult Post([FromBody]HotelDto dto, [FromServices]CreateHotelValidator createHotelValidator)
        {
            return null;
        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HotelDto dto, [FromServices]EditHotelValidator editHotelValidator)
        {
            return null;
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}
