using Application;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Logger
{
    public class LogToConsole : ILogger
    {
        public void Log(IAction action, IApplicationActor actor, object data)
        {
            Console.WriteLine($"{DateTime.Now}: {actor.Identity} is trying to execute {action.Name} using data: " +
                $"{JsonConvert.SerializeObject(data)}");
        }
    }
}
