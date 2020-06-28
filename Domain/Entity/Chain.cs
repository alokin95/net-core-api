using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Chain : EntityBase
    {
        public string Name { get; set; }
        public int ManagerId { get; set; }

        public virtual User Manager { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
