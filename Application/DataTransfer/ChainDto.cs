using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class ChainDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserDto Manager { get; set; }
        public IEnumerable<HotelDto> Hotels { get; set; } = new List<HotelDto>();
    }
}
