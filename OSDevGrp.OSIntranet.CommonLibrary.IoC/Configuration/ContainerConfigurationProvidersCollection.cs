using System.Configuration;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces.Exceptions;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Configuration
{
    /// <summary>
    /// Collection of Inversion of Control configuration providers.
    /// </summary>
    [ConfigurationCollection(typeof(ContainerConfigurationProvider))]
    internal class ContainerConfigurationProvidersCollection : ConfigurationElementCollection
    {
        #region Overrided methods

        /// <summary>
        /// Creates a new element.
        /// </summary>
        /// <returns>New element.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ContainerConfigurationProvider();
        }

        /// <summary>
        /// Get the key for an element.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <returns>Key for the element.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ContainerConfigurationProvider) element).Name;
        }

        #endregion

        /// <summary>
        /// Get a configuration provider using a key.
        /// </summary>
        /// <param name="name">Name of the configuration provider.</param>
        /// <returns>Configuration for the configuration provider.</returns>
        new public ContainerConfigurationProvider this[string name]
        {
            get
            {
                var containerConfigurationProvider = BaseGet(name) as ContainerConfigurationProvider;
                if (containerConfigurationProvider == null)
                {
                    throw new ContainerConfigurationException();
                }
                return containerConfigurationProvider;
            }
        }
    }
}
