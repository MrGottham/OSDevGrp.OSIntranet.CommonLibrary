using Castle.Windsor;

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

            return container;
        }
    }
}
