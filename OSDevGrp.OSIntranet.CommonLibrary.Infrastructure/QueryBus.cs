using System;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces.Exceptions;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces;
using OSDevGrp.OSIntranet.CommonLibrary.Resources;

namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure
{
    /// <summary>
    /// Implementering af en QueryBus.
    /// </summary>
    public class QueryBus : IQueryBus
    {
        #region Private variables

        private readonly IContainer _container;

        #endregion

        #region Constructor

        /// <summary>
        /// Danner en QueryBus.
        /// </summary>
        /// <param name="container">Container til Inversion of Control.</param>
        public QueryBus(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        #endregion

        #region IQueryBus Members

        /// <summary>
        /// Udfører en forespørgelse.
        /// </summary>
        /// <typeparam name="TQuery">Typen af forespørgelsen, der skal udføres.</typeparam>
        /// <typeparam name="TView">Typen, som forespørgelsen, skal returnerer.</typeparam>
        /// <param name="query">Forespørgelse.</param>
        /// <returns>Værdi, som forespørgelsen, skal returnerer.</returns>
        public TView Query<TQuery, TView>(TQuery query) where TQuery : class, IQuery
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var subscriber = _container.Resolve<IQueryHandler<TQuery, TView>>();
            if (subscriber == null)
            {
                throw new QueryBusException(
                    Resource.GetExceptionMessage(ExceptionMessage.NoQueryHandlerRegisteredForTypeAndReturnType,
                                                 typeof (TQuery), typeof (TView)));
            }

            throw new System.NotImplementedException();
        }

        #endregion
    }
}
