using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.DTO.Search;
using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly Database _dbContext;
        public LocationController(IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = new Database();
        }
        // GET: api/<LocationController>
        [HttpGet]
        public IActionResult Get([FromQuery]LocationSearch dto)
        {
            try
            {
                var locationsQuery = _dbContext.Locations.AsQueryable();

                if (dto.Country != null)
                {
                    locationsQuery = locationsQuery.Where(l => l.Country.ToLower().Contains(dto.Country.ToLower()));
                }

                var response = _mapper.Map<List<LocationDto>>(locationsQuery.ToList());

                return Ok(response);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var location = _dbContext.Locations.Find(id);
                
                if (location == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<LocationDto>(location););
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<LocationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
