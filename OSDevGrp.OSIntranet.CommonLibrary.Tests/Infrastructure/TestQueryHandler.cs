using System;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.Infrastructure
{
    /// <summary>
    /// Queryhandler, der kan benyttes til test af QueryBus.
    /// </summary>
    internal class TestQueryHandler : IQueryHandler<TestQuery, Guid>
    {
        #region IQueryHandler<TestQuery,Guid> Members

        /// <summary>
        /// Udfører forespørgelse.
        /// </summary>
        /// <param name="query">Forespørgelse.</param>
        /// <returns>Unik identifikator.</returns>
        public Guid Query(TestQuery query)
        {
            return Guid.NewGuid();
        }

        #endregion
    }
}
