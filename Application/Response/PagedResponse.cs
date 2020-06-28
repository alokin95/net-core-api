using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Response
{
    public class PagedResponse<T> where T : class
    {
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
