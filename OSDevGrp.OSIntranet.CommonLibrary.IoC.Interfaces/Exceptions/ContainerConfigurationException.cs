using System;
using System.Runtime.Serialization;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces.Exceptions
{
    /// <summary>
    /// Configuration exception for an Inversion of Control container.
    /// </summary>
    [Serializable]
    public class ContainerConfigurationException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ContainerConfigurationException()
        {
        }

        /// <summary>
        /// Creates a configuration exception for an Inversion of Control container.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ContainerConfigurationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a configuration exception for an Inversion of Control container.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public ContainerConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates a configuration exception for an Inversion of Control container.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected ContainerConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
