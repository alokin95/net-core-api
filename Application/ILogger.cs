using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface ILogger
    {
        void Log(IAction action, IApplicationActor actor, object data);
    }
}
