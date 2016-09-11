using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Installers
{
    [TestFixture]
    public class InstallerTest
    {
        [Test]
        public void installers_works()
        {
            using (WindsorContainer container = new WindsorContainer())
            {
                // usage
                container.Install(new IWindsorInstaller[] {
                    new DummyModuleInstaller()
                });

                // assert that service was installed

                // Windsor would throw ComponentNotFoundException if
                // the service was not installed
                DummyService serviceA = container.Resolve<DummyService>();
                DummyService serviceB = container.Resolve<DummyService>();

                // transient lifestyle
                Assert.That(serviceA, Is.Not.EqualTo(serviceB));
            }
        }
    }
}
