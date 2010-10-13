using System.Configuration;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Configuration
{
    /// <summary>
    /// Represents configuration for a container.
    /// </summary>
    internal class Container : ConfigurationElement
    {
        #region Properties

        /// <summary>
        /// Type of factory for the container.
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, IsKey = true)]
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
