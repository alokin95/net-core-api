using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entity
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Chain> Chains { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
