using System.Configuration;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Configuration
{
    /// <summary>
    /// Configuration section for Inversion of Control container configuration.
    /// </summary>
    internal class ConfigurationSectionHandler : ConfigurationSection
    {
        #region Properties

        /// <summary>
        /// Get collection of configuration providers.
        /// </summary>
        [ConfigurationProperty("containerConfigurationProviders", IsRequired = true, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ContainerConfigurationProvidersCollection), AddItemName = "add", ClearItemsName = "clear")]
        public ContainerConfigurationProvidersCollection ConfigurationProviders
        {
            get
            {
                return (ContainerConfigurationProvidersCollection) base["containerConfigurationProviders"];
            }
        }

        /// <summary>
        /// Get configuration for the container.
        /// </summary>
        [ConfigurationProperty("container", IsRequired = true, IsDefaultCollection = false)]
        public Container ContainerConfiguration
        {
            get
            {
                return (Container) base["container"];
            }
        }

        #endregion
    }
}
