using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer.Search
{
    public class ChainSearch : PagedSearch
    {
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
