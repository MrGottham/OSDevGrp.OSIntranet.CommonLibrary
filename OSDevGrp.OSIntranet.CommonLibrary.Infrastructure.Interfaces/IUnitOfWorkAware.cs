using System.Transactions;

namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface til brug for CommandHandlers, som gør, at CommandBus vil
    /// håndtere UnitOfWork (Transaction/Sessions) for kommandoen.
    /// </summary>
    public interface IUnitOfWorkAware
    {
        /// <summary>
        /// TransactionScopeOption.
        /// </summary>
        TransactionScopeOption TransactionScopeOption
        {
            get;
        }

        /// <summary>
        /// TransactionOptions.
        /// </summary>
        TransactionOptions TransactionOptions
        {
            get;
        }
    }
}
