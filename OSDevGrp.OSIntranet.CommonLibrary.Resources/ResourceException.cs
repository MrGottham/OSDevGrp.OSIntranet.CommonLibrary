using System;
using System.Runtime.Serialization;

namespace OSDevGrp.OSIntranet.CommonLibrary.Resources
{
    /// <summary>
    /// Resource exception.
    /// </summary>
    [Serializable]
    public class ResourceException : Exception
    {
        /// <summary>
        /// Creates a resource exception.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ResourceException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a resource exception.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public ResourceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates a resource exception.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected ResourceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
