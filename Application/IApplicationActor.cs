using System.Collections.Generic;

namespace Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; }
        public IEnumerable<int> AllowedActions { get; }
    }

}
