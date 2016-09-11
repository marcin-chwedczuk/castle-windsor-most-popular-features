using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Demo.CustomFacility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InjectCollections
{
    [TestFixture]
    public class InjectCollectionTest
    {
        [Test]
        public void inject_collection_works()
        {
            using (WindsorContainer container = new WindsorContainer())
            {
                // usage
                container.Kernel.Resolver.AddSubResolver(
                    new CollectionResolver(container.Kernel));

                // or using custom facility:
                // container.AddFacility<ResolveCollectionsFacility>();

                container.Register(
                        Component.For<MessageFilterService>().LifeStyle.Transient,

                        // singletons:
                        Component.For<IFilter>().ImplementedBy<RejectBazWordFilter>(),
                        Component.For<IFilter>().ImplementedBy<FooOrBazFilter>()
                    );

                // assert that service gets both filters
                MessageFilterService service = container.Resolve<MessageFilterService>();

                Assert.That(service.IsAllowed("foo"), Is.True);
                Assert.That(service.IsAllowed("baz"), Is.False);
                Assert.That(service.IsAllowed("fufu"), Is.False);
        }
    }
}
}
