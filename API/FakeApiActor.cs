using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "Chain manager";

        public IEnumerable<int> AllowedActions => new List<int> { 1 };
    }

    public class AdminFakeApiActor : IApplicationActor
    {
        public int Id => 2;

        public string Identity => "Hotel Manager";

        public IEnumerable<int> AllowedActions => Enumerable.Range(1, 30);
    }
}
