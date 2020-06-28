using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class RoomAmenity
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }

        public virtual Room Room { get; set; }
        public virtual Amenity Amenity { get; set; }
    }
}
