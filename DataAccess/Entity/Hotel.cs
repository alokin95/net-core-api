using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entity
{
    public class Hotel : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ManagerId { get; set; }
        public int ChainId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Chain Chain { get; set; }
        public virtual User Manager { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<HotelAmenity> Amenities { get; set; } = new HashSet<HotelAmenity>();
    }
}
