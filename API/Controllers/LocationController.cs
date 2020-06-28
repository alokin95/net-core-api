using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.DataTransfer.Search;
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
    public class LocationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly Database _dbContext;
        public LocationController(IMapper mapper, Database context)
        {
            _mapper = mapper;
            _dbContext = context;
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

                return Ok(_mapper.Map<LocationDto>(location));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<LocationController>
        [HttpPost]
        public IActionResult Post([FromBody]LocationDto dto,
            [FromServices]CreateLocationValidator createLocationValidator)
        {
            var validator = createLocationValidator.Validate(dto);

            if (!validator.IsValid)
            {
                //return validator.ValidationErrors();
            }

            var location = _mapper.Map<Location>(dto);

            try
            {
                _dbContext.Locations.Add(location);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]LocationDto dto,
            [FromServices]EditLocationValidator editLocationValidator)
        {
            dto.Id = id;

            var validator = editLocationValidator.Validate(dto);

            if (!validator.IsValid)
            {
                //return validator.ValidationErrors();
            }

            var location = _dbContext.Locations.Find(id);

            if (location == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, location);

            try
            {
                _dbContext.SaveChanges();
                return NoContent();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var location = _dbContext.Locations.Find(id);

            if (location == null)
            {
                return NotFound();
            }

            location.DeletedAt = DateTime.Now;
            location.isActive = false;

            try
            {
                _dbContext.SaveChanges();
                return NoContent();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
