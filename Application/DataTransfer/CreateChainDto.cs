using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CreateChainDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
    }
}
