using System;
using System.Runtime.Serialization;

namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces.Exceptions
{
    /// <summary>
    /// Exception fra en QueryBus.
    /// </summary>
    [Serializable]
    public class QueryBusException : Exception
    {
        /// <summary>
        /// Danner en exception fra en QueryBus.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public QueryBusException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Danner en exception fra en QueryBus.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public QueryBusException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Danner en exception fra en QueryBus.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected QueryBusException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
