﻿using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Demo.TypedFactory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.TypedFactory
{
    [TestFixture]
    public class TypedFactoryTest
    {
        [Test]
        public void typedfactory_case1_works()
        {
            EventTracer.ResetEvents();

            using (WindsorContainer container = new WindsorContainer())
            {
                // registration
                container.AddFacility<TypedFactoryFacility>();

                container.Register(
                    Component.For<ICommandHandler<AddUserCommand>>()
                        .ImplementedBy<AddUserCommandHandler>()
                        .LifeStyle.Transient,

                    Component.For<ICommandHandlerFactory>()
                        .AsFactory()
                    );

                // usage
                ICommandHandlerFactory factory = container.Resolve<ICommandHandlerFactory>();

                ICommandHandler<AddUserCommand> handler =
                    factory.Create<AddUserCommand>();

                handler.Handle(new AddUserCommand());

                factory.Release(handler);

                // check that everything works
                Assert.That(EventTracer.EventCount, Is.EqualTo(2));
                Assert.That(EventTracer.GetEvent(0), Is.EqualTo("USER ADDED"));
                Assert.That(EventTracer.GetEvent(1), Is.EqualTo("HANDLER DISPOSED"));
            }
        }

        [Test]
        public void typedfactory_case2_works()
        {
            EventTracer.ResetEvents();

            using (WindsorContainer container = new WindsorContainer())
            {
                // registration
                container.AddFacility<TypedFactoryFacility>();

                container.Register(
                    Component.For<IGreeter>()
                        .ImplementedBy<ConsoleGreeter>()
                        .LifestyleTransient(),

                    Component.For<IGreeterFactory>()
                        .AsFactory()
                    );

                // usage
                IGreeterFactory greeterFactory = 
                    container.Resolve<IGreeterFactory>();

                IGreeter helloWorldGreeter = greeterFactory.Create("hello, world!");
                IGreeter goodbyeGreeter = greeterFactory.Create("goodbye cruel world!");

                helloWorldGreeter.Greet();
                goodbyeGreeter.Greet();

                greeterFactory.Release(helloWorldGreeter);
                greeterFactory.Release(goodbyeGreeter);

                // what happened
                Assert.That(EventTracer.EventCount, Is.EqualTo(4));

                Assert.That(EventTracer.GetEvent(0), Is.EqualTo("GREETER CREATED: hello, world!"));
                Assert.That(EventTracer.GetEvent(1), Is.EqualTo("GREETER CREATED: goodbye cruel world!"));
            
                Assert.That(EventTracer.GetEvent(2), Is.EqualTo("GREETER DISPOSED: hello, world!"));
                Assert.That(EventTracer.GetEvent(3), Is.EqualTo("GREETER DISPOSED: goodbye cruel world!"));}
        }
    }
}
