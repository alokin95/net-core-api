using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class LogDto
    {
        public int Id { get; set; }
        public DateTime HappenedAt { get; set; }
        public int UserId { get; set; }
        public int Actionid { get; set; }
        public string ActionName { get; set; }
        public string ActorIdentity { get; set; }
    }
}
