using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO.Search
{

    public class HotelSearch : LocationSearch
    {
        public string Name { get; set; }
    }
}
