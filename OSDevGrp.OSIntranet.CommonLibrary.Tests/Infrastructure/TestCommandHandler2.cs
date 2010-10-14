using System;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces.Core;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.Infrastructure
{
    /// <summary>
    /// Commandhandler, der kan benyttes til test af CommandBus.
    /// </summary>
    internal class TestCommandHandler2 : CommandHandlerTransactionalBase, ICommandHandler<TestCommand, Guid>
    {
        #region ICommandHandler<TestCommand,Guid> Members

        /// <summary>
        /// Udførelse af kommando.
        /// </summary>
        /// <param name="command">Kommando.</param>
        /// <returns>Unik identifikator.</returns>
        public Guid Execute(TestCommand command)
        {
            if (command.ExceptionToThrow != null)
            {
                throw command.ExceptionToThrow;
            }
            return Guid.NewGuid();
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
