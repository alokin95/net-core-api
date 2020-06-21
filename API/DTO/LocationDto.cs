using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class LocationDto
    {
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }

        public HotelDto Hotel { get; set; }
    }
}
