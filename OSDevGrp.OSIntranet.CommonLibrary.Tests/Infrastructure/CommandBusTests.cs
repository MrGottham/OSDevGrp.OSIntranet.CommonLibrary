using System;
using System.Collections.Generic;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces;
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
        /// Tester, at Publish kalder commandhandler(s).
        /// </summary>
        [Test]
        public void TestAtPublishKalderCommandHandlers()
        {
            var commandBus = new CommandBus(CreateContainer());
            var command1 = new TestCommand
                               {
                                   Modified = false,
                                   ExceptionToThrow = null
                               };
            var command2 = new TestCommand
                               {
                                   Modified = false,
                                   ExceptionToThrow = null
                               };
            commandBus.Publish(command1);
            Assert.That(command1, Is.Not.Null);
            Assert.That(command1.Modified, Is.True);

            command1.Modified = false;
            command2.Modified = false;
            var commands = new List<TestCommand>
                               {
                                   command1,
                                   command2
                               };
            commandBus.Publish<TestCommand>(commands);
            Assert.That(command1, Is.Not.Null);
            Assert.That(command1.Modified, Is.True);
            Assert.That(command2, Is.Not.Null);
            Assert.That(command2.Modified, Is.True);

            command1.Modified = false;
            command2.Modified = false;
            var id = commandBus.Publish<TestCommand, Guid>(command1);
            Assert.That(id, Is.Not.Null);
            Assert.That(id.GetType(), Is.EqualTo(typeof(Guid)));
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(command1, Is.Not.Null);
            Assert.That(command1.Modified, Is.True);
        }

        /// <summary>
        /// Tester, at Publish kalder exceptionhandler(s).
        /// </summary>
        [Test]
        public void TestAtPublishKalderExceptionHandlers()
        {
            var commandBus = new CommandBus(CreateContainer());
            var command1 = new TestCommand
                               {
                                   Modified = false,
                                   ExceptionToThrow = new NotSupportedException()
                               };
            var command2 = new TestCommand
                               {
                                   Modified = false,
                                   ExceptionToThrow = new NotSupportedException()
                               };
            commandBus.Publish(command1);
            Assert.That(command1, Is.Not.Null);
            Assert.That(command1.Modified, Is.False);

            command1.Modified = false;
            command2.Modified = false;
            var commands = new List<TestCommand>
                               {
                                   command1,
                                   command2
                               };
            commandBus.Publish<TestCommand>(commands);
            Assert.That(command1, Is.Not.Null);
            Assert.That(command1.Modified, Is.False);
            Assert.That(command2, Is.Not.Null);
            Assert.That(command2.Modified, Is.False);

            command1.Modified = false;
            command2.Modified = false;
            commandBus.Publish<TestCommand, Guid>(command1);
            Assert.That(command1, Is.Not.Null);
            Assert.That(command1.Modified, Is.False);
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
            var commandHandler1 = new TestCommandHandler1();
            var commandHandler2 = new TestCommandHandler2();
            container.Expect(m => m.ResolveAll<ICommandHandler<TestCommand>>()).Return(new[] {commandHandler1});
            container.Expect(m => m.Resolve<ICommandHandler<TestCommand, Guid>>()).Return(commandHandler2);
            return container;
        }
    }
}
