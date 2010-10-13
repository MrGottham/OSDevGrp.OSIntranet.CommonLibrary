using Castle.MicroKernel.Registration;
using Castle.Windsor;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces.Windsor;
using OSDevGrp.OSIntranet.CommonLibrary.Tests.IoC.TestObjects;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.IoC.ConfigurationProviders
{
    /// <summary>
    /// Configuration provider til test.
    /// </summary>
    public class TestConfigurationProvider2 : IConfigurationProvider
    {
        #region IConfigurationProvider Members

        /// <summary>
        /// Adding configuration to the container.
        /// </summary>
        /// <param name="container">Container to add configuration to.</param>
        public void AddConfiguration(IWindsorContainer container)
        {
            container.Register(Component.For<ISomeComponent>().ImplementedBy<SomeComponent>().LifeStyle.Transient);
            container.Register(Component.For<ISomeOtherComponent>().ImplementedBy<SomeOtherComponent>());
        }

        #endregion
    }
}
