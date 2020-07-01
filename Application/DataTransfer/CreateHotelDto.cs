using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CreateHotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationDto Location { get; set; }
        public int ManagerId { get; set; }
        public int ChainID { get; set; }
        public IEnumerable<HotelAmenityDto> Amenities { get; set; } = new List<HotelAmenityDto>();
    }

    public class HotelAmenityDto
    {
        public int HotelId { get; set; }
        public int AmenityId { get; set; }
    }
}
