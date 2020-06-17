using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entity
{
    public class Location : EntityBase
    {
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
