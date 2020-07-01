using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer.Search
{
    public class UserSearch : PagedSearch
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
