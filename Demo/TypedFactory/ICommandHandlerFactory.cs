using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.TypedFactory
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> Create<T>();
        void Release<T>(ICommandHandler<T> instance);
    }
}
