using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CreateRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HotelId { get; set; }
        public string Description { get; set; }
        public IEnumerable<RoomAmenityDto> Amenities { get; set; } = new List<RoomAmenityDto>();
    }

    public class RoomAmenityDto
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }
    }
}
