using Castle.MicroKernel.Registration;
using Castle.Windsor;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces.Windsor;
using OSDevGrp.OSIntranet.CommonLibrary.Wcf.ChannelFactory;

namespace OSDevGrp.OSIntranet.CommonLibrary.Wcf.Configuraiton
{
    /// <summary>
    /// Registrering af WCF komponenter.
    /// </summary>
    public class WcfConfigurationProvider : IConfigurationProvider
    {
        #region IConfigurationProvider Members

        /// <summary>
        /// Tilføjelse af komponenter til containeren.
        /// </summary>
        /// <param name="container">Container til Inversion of Control.</param>
        public void AddConfiguration(IWindsorContainer container)
        {
            container.Register(Component.For<IChannelFactory>().ImplementedBy<DefaultChannelFactory>().LifeStyle.Transient);
        }

        #endregion
    }
}
