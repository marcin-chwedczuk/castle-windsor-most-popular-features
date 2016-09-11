using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InjectCollections
{
    class FooOrBazFilter : IFilter
    {
        public bool IsAllowed(string message)
        {
            return 
                "foo".Equals(message, StringComparison.InvariantCultureIgnoreCase) ||
                "baz".Equals(message, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
