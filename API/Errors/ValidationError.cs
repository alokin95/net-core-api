using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ValidationError
    {
        public string Property { get; set; }
        public string Message { get; set; }
    }
}
