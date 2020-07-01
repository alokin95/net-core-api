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
    }
}
