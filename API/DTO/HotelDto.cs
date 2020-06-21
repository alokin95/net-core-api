using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}
