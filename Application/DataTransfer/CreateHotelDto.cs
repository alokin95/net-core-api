using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CreateHotelDto
    {
        public string Name { get; set; }
        public LocationDto Location { get; set; }
        public int ManagerId { get; set; }
        public int ChainID { get; set; }
    }
}
