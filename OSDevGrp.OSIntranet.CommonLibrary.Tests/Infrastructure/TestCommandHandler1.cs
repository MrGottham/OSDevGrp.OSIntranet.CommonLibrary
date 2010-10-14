using System;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces.Core;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.Infrastructure
{
    /// <summary>
    /// Commandhandler, der kan benyttes til test af CommandBus.
    /// </summary>
    internal class TestCommandHandler1 : CommandHandlerTransactionalBase, ICommandHandler<TestCommand>
    {
        #region ICommandHandler<TestCommand> Members

        /// <summary>
        /// Udførelse af kommando.
        /// </summary>
        /// <param name="command">Kommando.</param>
        public void Execute(TestCommand command)
        {
            command.Modified = true;
            if (command.ExceptionToThrow != null)
            {
                throw command.ExceptionToThrow;
            }
        }

        /// <summary>
        /// Exceptionhandler.
        /// </summary>
        /// <param name="command">Kommando.</param>
        /// <param name="exception">Exception, der blev kastet.</param>
        public void HandleException(TestCommand command, Exception exception)
        {
            command.Modified = false;
        }

        #endregion
    }
}
