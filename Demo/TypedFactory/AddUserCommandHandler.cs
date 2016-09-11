using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.TypedFactory
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand>, IDisposable
    {
        public void Dispose()
        {
            EventTracer.AddEvent("HANDLER DISPOSED");
        }

        public void Handle(AddUserCommand command)
        {
            EventTracer.AddEvent("USER ADDED");
        }
    }
}
