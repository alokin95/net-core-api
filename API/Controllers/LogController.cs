using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DataTransfer.Search;
using Application.Queries.LogQueries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ActionDispatcher _dispatcher;

        public LogController(ActionDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get([FromQuery]LogSearch search,
            [FromServices]IGetLogsQuery getLogsQuery)
        {
            return Ok(_dispatcher.DispatchQuery(getLogsQuery, search));
        }
    }
}
