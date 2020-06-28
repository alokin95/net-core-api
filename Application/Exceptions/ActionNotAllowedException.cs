using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ActionNotAllowedException : Exception
    {
        public ActionNotAllowedException(IAction action, IApplicationActor actor)
            : base($"Actor with an id of {actor.Id} - {actor.Identity} tried to execute {action.Name}.")
        {

        }
    }
}
