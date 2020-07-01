using Application;
using DataAccess;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Logger
{
    public class LogToDatabase : ILogger
    {
        private readonly Database context;

        public LogToDatabase(Database context)
        {
            this.context = context;
        }

        public void Log(IAction action, IApplicationActor actor, object data)
        {
            /*var log = new ApplicationLog
            {
                Actionid = action.Id,
                ActionName = action.Name,
                ActorIdentity = actor.Identity,
                HappenedAt = DateTime.Now,
                UserId = actor.Id
            };*/

            this.context.AppLogs.Add(new ApplicationLog
            {
                Actionid = action.Id,
                ActionName = action.Name,
                ActorIdentity = actor.Identity,
                UserId = actor.Id
            });
            this.context.SaveChanges();
        }
    }
}
