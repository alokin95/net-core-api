using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}
