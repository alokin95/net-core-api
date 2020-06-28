using Application.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class ActionDispatcher
    {
        private readonly IApplicationActor actor;
        private readonly ILogger logger;

        public ActionDispatcher(IApplicationActor actor, ILogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public TResult DispatchQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            logger.Log(query, actor, search);

            if (!actor.AllowedActions.Contains(query.Id))
            {
                throw new ActionNotAllowedException(query, actor);
            }

            return query.Execute(search);
        }

        public void DispatchCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request)
        {
            logger.Log(command, actor, request);

            if (!actor.AllowedActions.Contains(command.Id))
            {
                throw new ActionNotAllowedException(command, actor);
            }

            command.Execute(request);
        }
    }
}
