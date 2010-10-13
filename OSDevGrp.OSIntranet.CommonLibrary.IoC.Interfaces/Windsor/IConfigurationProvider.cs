using Castle.Windsor;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces.Windsor
{
    /// <summary>
    /// Interface for a configuration provider to Windsor Container.
    /// </summary>
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Method for adding configuration to container.
        /// </summary>
        /// <param name="container">Container to add configuration to.</param>
        void AddConfiguration(IWindsorContainer container);
    }
}
