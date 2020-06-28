using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface ICommand<TRequest> : IAction
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TSearch, TResult> : IAction
    {
        TResult Execute(TSearch search);
    }

    public interface IAction
    {
        int Id { get; }
        string Name { get; }
    }
}
