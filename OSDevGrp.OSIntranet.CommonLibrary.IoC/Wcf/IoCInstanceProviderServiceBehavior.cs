using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Wcf
{
    /// <summary>
    /// Servicebehavior, som sætter custom instanceprovider, så afhængigheder kan injectes i services.
    /// </summary>
    public class IoCInstanceProviderServiceBehavior : IServiceBehavior
    {
        #region IServiceBehavior Members

        /// <summary>
        /// Provides the ability to pass custom data to binding elements to support contract implementation.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The host of the service.</param>
        /// <param name="endpoints">The service endpoints.</param>
        /// <param name="bindingParameters">Custom objects to which binding elements have access.</param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Provides the ability to change runtime property values or insert custom extension objects such as error handles, messages or parameter interceptors, security extensions and other custom extension objects.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The host of the service.</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            if (serviceDescription == null)
            {
                throw new ArgumentNullException("serviceDescription");
            }
            if (serviceHostBase == null)
            {
                throw new ArgumentNullException("serviceHostBase");
            }
            foreach (var endpointDispatcher in serviceHostBase.ChannelDispatchers
                .OfType<ChannelDispatcher>()
                .SelectMany(channelDispatcher => channelDispatcher.Endpoints))
            {
                endpointDispatcher.DispatchRuntime.InstanceProvider =
                    new IoCInstanceProvider(serviceDescription.ServiceType);
            }
        }

        /// <summary>
        /// Provides the ability to inspect the service host and the service description to confirm that the service can run successfully.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host that is currently being constructed.</param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        #endregion
    }
}
