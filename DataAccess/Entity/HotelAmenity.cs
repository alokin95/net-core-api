using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entity
{
    public class HotelAmenity
    {
        public int HotelId { get; set; }
        public int AmenityId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Amenity Amenity { get; set; }
    }
}
