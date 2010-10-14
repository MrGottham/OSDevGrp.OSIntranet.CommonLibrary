using System;
using System.Runtime.Serialization;

namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces.Exceptions
{
    /// <summary>
    /// Exception fra en CommandBus.
    /// </summary>
    [Serializable]
    public class CommandBusException : Exception
    {
        /// <summary>
        /// Danner en exception fra en CommandBus.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public CommandBusException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Danner en exception fra en CommandBus.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CommandBusException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Danner en exception fra en CommandBus.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected CommandBusException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
