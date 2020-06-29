using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id)
            : base($"Entity with an ID of {id} was not found on the server")
        {

        }
    }
}
