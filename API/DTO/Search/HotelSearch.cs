using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO.Search
{

    public class HotelSearch
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
