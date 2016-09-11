using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InjectCollections
{
    public class RejectBazWordFilter : IFilter
    {
        public bool IsAllowed(string message)
        {
            return !"baz".Equals(message, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
