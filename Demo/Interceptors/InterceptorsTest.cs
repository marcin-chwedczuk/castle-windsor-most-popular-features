using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interceptors
{
    [TestFixture]
    public class InterceptorsTest
    {
        [Test]
        public void interceptors_works()
        {
            EventTracer.ResetEvents();

            using (WindsorContainer container = new WindsorContainer())
            {
                // often we may use facility and custom attributes
                // to attach interceptors

                container.Register(
                    // interceptors work only when you resolve your
                    // types via interfaces.
                    // here I registered interceptors by using
                    // attributes on Service class but you may also
                    // use fluent api.
                    Component.For<IService>().ImplementedBy<Service>(),
                    Component.For<EventTracingInterceptor>()
                    );

                IService service = container.Resolve<IService>();

                service.Foo();

                // assert that it worked
                Assert.That(EventTracer.EventCount, Is.EqualTo(3));
                Assert.That(EventTracer.GetEvent(0), Is.EqualTo("BEFORE Foo"));
                Assert.That(EventTracer.GetEvent(1), Is.EqualTo("FOO CALLED"));
                Assert.That(EventTracer.GetEvent(2), Is.EqualTo("AFTER Foo"));
            }
        }
    }
}
