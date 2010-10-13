using System;
using Castle.Windsor;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Configuration;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces.Windsor;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Windsor
{
    /// <summary>
    /// Static factory using WindsorContainer to resolve objects.
    /// </summary>
    internal static class ContainerConfiguration
    {
        /// <summary>
        /// Get configured instance.
        /// </summary>
        /// <returns>Instance of a configured container.</returns>
        public static IWindsorContainer GetConfiguredInstance()
        {
            IWindsorContainer container = new WindsorContainer();

            foreach (var providerType in ConfigurationReader.ConfigurationProviders)
            {
                var provider = (IConfigurationProvider) Activator.CreateInstance(providerType);
                provider.AddConfiguration(container);
            }

            return container;
        }
    }
}
