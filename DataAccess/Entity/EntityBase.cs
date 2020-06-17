using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entity
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool isActive { get; set; }

    }
}
