using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Room : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int HotelId { get; set; }
        public virtual ICollection<RoomAmenity> Amenities { get; set; } = new HashSet<RoomAmenity>();
        public virtual Hotel Hotel { get; set; }
    }
}
