using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class ApplicationLog : EntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Actionid { get; set; }
        public string ActionName { get; set; }
        public string ActorIdentity { get; set; }
    }
}
