using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer.Search
{
    public class LogSearch : PagedSearch
    {
        public int Id { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int UserId { get; set; }
        public int Actionid { get; set; }
        public string ActionName { get; set; }
        public string ActorIdentity { get; set; }
    }
}
