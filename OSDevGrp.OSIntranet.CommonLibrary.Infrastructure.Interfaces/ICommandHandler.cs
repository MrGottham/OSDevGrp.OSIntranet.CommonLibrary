using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces
{
    /// <summary>
    /// Marker interface.
    /// </summary>
    public interface ICommandHandler
    {
    }

    /// <summary>
    /// Interface til CommandHandlers, som ikke returnerer en værdi.
    /// </summary>
    /// <typeparam name="TCommand">Typen af kommandoen, som CommandHandleren håndterer.</typeparam>
    public interface ICommandHandler<in TCommand> : ICommandHandler, IUnitOfWorkAware where TCommand : class, ICommand
    {
        /// <summary>
        /// Eksekvering af kommandoen.
        /// </summary>
        /// <param name="command">Kommando, som eksekveres.</param>
        void Execute(TCommand command);

        /// <summary>
        /// Handle exception.
        /// </summary>
        /// <param name="command">Kommando, som eksekveres.</param>
        /// <param name="exception">Exception, som er opstået under eksekvering.</param>
        void HandleException(TCommand command, Exception exception);
    }

    /// <summary>
    /// Interface til CommandHandlers, som returnerer en værdi.
    /// </summary>
    /// <typeparam name="TCommand">Typen af kommandoen, som CommandHandleren håndterer.</typeparam>
    /// <typeparam name="TReturnValue">Typen af returværdien.</typeparam>
    public interface ICommandHandler<in TCommand, out TReturnValue> : ICommandHandler, IUnitOfWorkAware where TCommand : class, ICommand
    {
        /// <summary>
        /// Eksekvering af kommandoen.
        /// </summary>
        /// <param name="command">Kommando, som eksekveres.</param>
        /// <returns>Resultat af kommandoen.</returns>
        TReturnValue Execute(TCommand command);

        /// <summary>
        /// Handle exception.
        /// </summary>
        /// <param name="command">Kommando, som eksekveres.</param>
        /// <param name="exception">Exception, som er opstået under eksekvering.</param>
        void HandleException(TCommand command, Exception exception);
    }
}
