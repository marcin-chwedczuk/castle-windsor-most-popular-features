using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.FallbackAndDefaultComponents
{
    [TestFixture]
    public class FallbackAndDefaultComponentTest
    {
        [Test]
        public void fallback_and_default_component_works()
        {
            using (WindsorContainer container = new WindsorContainer())
            {
                // fallback is used when no other component
                // for service is registered
                container.Register(
                    Component.For<IFooService>()
                        .ImplementedBy<FallbackFooService>()
                        .LifeStyle.Transient
                        .IsFallback()
                        );

                Assert.That(container.Resolve<IFooService>(),
                    Is.InstanceOf<FallbackFooService>());

                // we may register our own component for FooService
                container.Register(
                    Component.For<IFooService>()
                        .ImplementedBy<FooService>()
                        );

                Assert.That(container.Resolve<IFooService>(),
                    Is.InstanceOf<FooService>());

                // sometime we want to override registration
                // e.g. from other installer, we may do this
                // using IsDefault(). Without IsDefault() we
                // would get an exception telling us that
                // there is already component registered for IFooService
                // interface.
                container.Register(
                   Component.For<IFooService>()
                       .ImplementedBy<DefaultFooService>()
                       .IsDefault()
                       );
                
                Assert.That(container.Resolve<IFooService>(),
                    Is.InstanceOf<DefaultFooService>());
            }
        }
    }
}
