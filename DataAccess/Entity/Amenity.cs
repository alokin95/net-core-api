using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entity
{
    public class Amenity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<HotelAmenity> Hotels { get; set; } = new HashSet<HotelAmenity>();
        public virtual ICollection<RoomAmenity> Rooms { get; set; } = new HashSet<RoomAmenity>();
    }
}
