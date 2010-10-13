using System.Configuration;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Configuration
{
    /// <summary>
    /// Configuration of Inversion of Control configuration provider.
    /// </summary>
    internal class ContainerConfigurationProvider : ConfigurationElement
    {
        #region Properties

        /// <summary>
        /// Name of the configuration provider.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string) this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        /// <summary>
        /// Configuration provider type.
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get
            {
                return (string) this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }

        #endregion
    }
}
