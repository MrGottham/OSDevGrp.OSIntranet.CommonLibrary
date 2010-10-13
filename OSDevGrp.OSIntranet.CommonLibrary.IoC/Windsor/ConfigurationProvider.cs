using Castle.MicroKernel.Registration;
using Castle.Windsor;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces.Windsor;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Windsor
{
    /// <summary>
    /// Registration for the container itself.
    /// </summary>
    public class ConfigurationProvider : IConfigurationProvider
    {
        #region IConfigurationProvider Members

        /// <summary>
        /// Adding configuration to the container.
        /// </summary>
        /// <param name="container">Container to add configuration to.</param>
        public void AddConfiguration(IWindsorContainer container)
        {
            var internalContainer = ContainerFactory.Create();
            container.Register(Component.For<IContainer>().Instance(internalContainer));
        }

        #endregion
    }
}
