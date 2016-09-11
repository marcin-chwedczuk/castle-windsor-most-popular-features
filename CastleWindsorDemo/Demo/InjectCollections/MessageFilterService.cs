using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InjectCollections
{
    public class MessageFilterService
    {
        private ICollection<IFilter> _filters;

        public MessageFilterService(ICollection<IFilter> filters)
        {
            this._filters = filters;
        }

        public bool IsAllowed(string message)
        {
            foreach (var filter in _filters)
            {
                if (!filter.IsAllowed(message))
                    return false;
            }

            return true;
        }
    }
}
