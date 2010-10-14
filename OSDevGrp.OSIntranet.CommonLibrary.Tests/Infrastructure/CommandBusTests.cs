using System;
using System.Collections.Generic;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces.Exceptions;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.Infrastructure
{
    /// <summary>
    /// Tester implementering af en CommandBus.
    /// </summary>
    [TestFixture]
    public class CommandBusTests
    {
        /// <summary>
        /// Tester, at konstruktøren kaster en ArgumentNullException, hvis container er null.
        /// </summary>
        [Test]
        public void TestAtConstructorKasterArgumentNullExceptionHvisContainerErNull()
        {
            Assert.Throws<ArgumentNullException>(() => new CommandBus(null));
        }

        /// <summary>
        /// Tester, at Publish kaster en ArgumentNullException, hvis command(s) er null.
        /// </summary>
        [Test]
        public void TestAtPublishKasterArgumentNullExceptionHvisCommandErNull()
        {
            var commandBus = new CommandBus(CreateContainer());

            TestCommand command = null;
            Assert.Throws<ArgumentNullException>(() => commandBus.Publish(command));

            IList<TestCommand> commands = null;
            Assert.Throws<ArgumentNullException>(() => commandBus.Publish(commands));

            Assert.Throws<ArgumentNullException>(() => commandBus.Publish<TestCommand, Guid>(null));
        }

        /// <summary>
        /// Tester, at Publish kaster en CommandBusException, hvis der ikke er registreret en commandhandler.
        /// </summary>
        [Test]
        public void TestAtPublishKasterCommandBusExceptionHvisCommandHandlerIkkeErRegistreret()
        {
            var commandBus = new CommandBus(CreateContainer());

            var command = new TestCommandWithoutCommandHandler();
            Assert.Throws<CommandBusException>(() => commandBus.Publish(command));
            Assert.Throws<CommandBusException>(() => commandBus.Publish<TestCommandWithoutCommandHandler, Guid>(command));
        }

        /// <summary>
        /// Danner en container, som kan benyttes til test af en CommandBus.
        /// </summary>
        /// <returns>Container til Inversion of Control.</returns>
        private static IContainer CreateContainer()
        {
            var container = MockRepository.GenerateMock<IContainer>();
            return container;
        }
    }
}
