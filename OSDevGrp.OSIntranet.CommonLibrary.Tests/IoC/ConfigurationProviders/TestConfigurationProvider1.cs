using System.Collections;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces.Windsor;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.IoC.ConfigurationProviders
{
    /// <summary>
    /// Configuration provider til test.
    /// </summary>
    public class TestConfigurationProvider1 : IConfigurationProvider
    {
        #region IConfigurationProvider Members

        /// <summary>
        /// Adding configuration to the container.
        /// </summary>
        /// <param name="container">Container to add configuration to.</param>
        public void AddConfiguration(IWindsorContainer container)
        {
            container.Register(Component.For<IEnumerable>().ImplementedBy<SortedList>());
            container.Register(Component.For<IEnumerable>().ImplementedBy<Queue>());
        }

        #endregion
    }
}
