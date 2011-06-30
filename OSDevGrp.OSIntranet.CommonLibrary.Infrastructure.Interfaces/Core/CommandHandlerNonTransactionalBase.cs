using System.Transactions;

namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces.Core
{
    /// <summary>
    /// Basisklasse for en commandhandler, der ikke understøtter transaktioner.
    /// </summary>
    public abstract class CommandHandlerNonTransactionalBase : CommandHandlerBase, IUnitOfWorkAware
    {
        #region IUnitOfWorkAware Members

        /// <summary>
        /// TransactionScopeOption.
        /// </summary>
        public TransactionScopeOption TransactionScopeOption
        {
            get
            {
                return TransactionScopeOption.Suppress;
            }
        }

        /// <summary>
        /// TransactionOptions
        /// </summary>
        public TransactionOptions TransactionOptions
        {
            get
            {
                return new TransactionOptions();
            }
        }

        #endregion
    }
}
