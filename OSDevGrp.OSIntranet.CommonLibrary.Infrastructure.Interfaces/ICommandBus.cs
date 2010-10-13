namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface til en CommandBus.
    /// </summary>
    public interface ICommandBus
    {
        /// <summary>
        /// Publicering kommando uden returværdi.
        /// </summary>
        /// <typeparam name="TCommand">Typen af kommandoen, som skal publiceres.</typeparam>
        /// <param name="command">Kommando, der skal publiceres.</param>
        void Publish<TCommand>(TCommand command) where TCommand : class, ICommand;

        /// <summary>
        /// Publicering kommando med returværdi.
        /// </summary>
        /// <typeparam name="TCommand">Typen af kommandoen, som skal publiceres.</typeparam>
        /// <typeparam name="TReturnValue">Typen af værdien, som kommandoen skal returnerer.</typeparam>
        /// <param name="command">Kommando, der skal publiceres.</param>
        /// <returns>Værdi, som kommandoen returnerer efter eksekvering.</returns>
        TReturnValue Publish<TCommand, TReturnValue>(TCommand command) where TCommand : class, ICommand;
    }
}
