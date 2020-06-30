using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DataTransfer.Search
{
    public class AmenitySearch : PagedSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
