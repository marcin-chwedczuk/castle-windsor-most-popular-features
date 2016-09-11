using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Autofactory
{
    public class ConsoleGreeter : IGreeter, IDisposable
    {
        private string _greeting;

        public ConsoleGreeter(string greeting)
        {
            if (string.IsNullOrWhiteSpace(greeting))
                throw new ArgumentException("greeting cannot be empty");

            EventTracer.AddEvent("GREETER CREATED: " + greeting);
            _greeting = greeting;
        }

        public void Dispose() {
            EventTracer.AddEvent("GREETER DISPOSED: " + _greeting);
        }

        public void Greet()
        {
            Console.WriteLine(_greeting);
        }
    }
}
