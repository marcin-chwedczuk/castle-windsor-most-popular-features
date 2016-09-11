using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interceptors
{
    public class EventTracingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            EventTracer.AddEvent("BEFORE " + invocation.Method.Name);

            try
            {
                invocation.Proceed();
            }
            finally
            {
                EventTracer.AddEvent("AFTER " + invocation.Method.Name);
            }
        }
    }
}
