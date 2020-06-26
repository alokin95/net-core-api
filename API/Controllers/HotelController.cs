using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.DTO.Search;
using API.Errors;
using API.Extensions;
using API.Response;
using API.Validations;
using AutoMapper;
using DataAccess;
using DataAccess.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly Database _dbContext;
        private readonly IMapper _mapper;
        public HotelController(IMapper mapper, Database context)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        // GET: api/<HotelController>
        [HttpGet]
        public IActionResult Get([FromQuery]HotelSearch dto)
        {
            try
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
            }
        }

        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var hotel = _dbContext.Hotels.Find(id);

                if (hotel == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<HotelDto>(hotel));
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<HotelController>
        [HttpPost]
        public IActionResult Post([FromBody]HotelDto dto, [FromServices]CreateHotelValidator createHotelValidator)
        {
            var result = createHotelValidator.Validate(dto);

            if (!result.IsValid)
            {
                return result.ValidationErrors();
            }

            var hotel = _mapper.Map<Hotel>(dto);

            try
            {
                _dbContext.Hotels.Add(hotel);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HotelDto dto, [FromServices]EditHotelValidator editHotelValidator)
        {
            var hotel = _dbContext.Hotels.Find(dto.Id);

            if (hotel == null)
            {
                return NotFound();
            }

            var validation = editHotelValidator.Validate(dto);

            if (!validation.IsValid)
            {
                return validation.ValidationErrors();
            }

            _mapper.Map(dto, hotel);

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

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hotel = _dbContext.Hotels.Find(id);

            if  (hotel == null)
            {
                return NotFound();
            }

            hotel.isActive = false;
            hotel.DeletedAt = DateTime.Now;

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
