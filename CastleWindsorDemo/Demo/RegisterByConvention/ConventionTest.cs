using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RegisterByConvention
{
    [TestFixture]
    public class ConventionTest
    {
        [Test]
        public void registration_by_convention_works()
        {
            using (WindsorContainer container = new WindsorContainer())
            {
                // usage
                container.Register(
                    // registered classes must be *public*
                    Classes.FromThisAssembly()
                        .BasedOn(typeof(IRepository<>))
                        .WithService.AllInterfaces()
                        .LifestyleTransient()
                    );

                // assert that both services were registered
                IRepository<Foo> fooRepo = container.Resolve<IRepository<Foo>>();
                IRepository<Bar> barRepo = container.Resolve<IRepository<Bar>>();

                Assert.That(fooRepo.Find(10).Id, Is.EqualTo(10));
                Assert.That(barRepo.Find(13).Id, Is.EqualTo(13));
            }
        }
    }
}
