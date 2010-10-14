using System;
using System.Transactions;

namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces.Core
{
    /// <summary>
    /// Basisklasse for en commandhandler, der understøtter transaktioner.
    /// </summary>
    public abstract class CommandHandlerTransactionalBase : CommandHandlerBase, IUnitOfWorkAware
    {
        #region IUnitOfWorkAware Members

        /// <summary>
        /// TransactionScopeOption.
        /// </summary>
        public TransactionScopeOption TransactionScopeOption
        {
            get
            {
                return TransactionScopeOption.Required;
            }
        }

        /// <summary>
        /// TransactionOptions
        /// </summary>
        public TransactionOptions TransactionOptions
        {
            get
            {
                return new TransactionOptions
                           {
                               IsolationLevel = IsolationLevel.Serializable,
                               Timeout = new TimeSpan(0, 0, 5, 0)
                           };
            }
        }

        #endregion
    }
}
