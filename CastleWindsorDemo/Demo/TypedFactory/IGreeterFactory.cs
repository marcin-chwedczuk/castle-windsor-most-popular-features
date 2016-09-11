using Demo.Autofactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.TypedFactory
{
    public interface IGreeterFactory
    {
        IGreeter Create(string greeting);
        void Release(IGreeter instance);
    }
}
