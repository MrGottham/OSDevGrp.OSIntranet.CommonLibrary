using System;
using System.Runtime.Serialization;

namespace OSDevGrp.OSIntranet.CommonLibrary.Repositories.Interface.Exceptions
{
    /// <summary>
    /// Common repository exception.
    /// </summary>
    [Serializable]
    public class CommonRepositoryException : Exception
    {
        /// <summary>
        /// Danner common repository exception.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public CommonRepositoryException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Danner common repository exception.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public CommonRepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Danner common repository exception.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected CommonRepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
