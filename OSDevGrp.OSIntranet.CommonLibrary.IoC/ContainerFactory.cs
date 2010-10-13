using System;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Configuration;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC
{
    /// <summary>
    /// Factory for creating instance of container. This static class should only be used in the
    /// rare circumstance where an instance of the container is not created yet and therefore is
    /// not able to resolve itself.
    /// </summary>
    public static class ContainerFactory
    {
        /// <summary>
        /// Create an instance of IContainer.
        /// </summary>
        /// <returns>New instance of IContainer.</returns>
        public static IContainer Create()
        {
            return (IContainer) Activator.CreateInstance(ConfigurationReader.ContainerType);
        }
    }
}
