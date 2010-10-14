using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace OSDevGrp.OSIntranet.CommonLibrary.Wcf.ChannelFactory
{
    /// <summary>
    /// Default custom channel factory.
    /// </summary>
    public class DefaultChannelFactory : IChannelFactory
    {
        #region IChannelFactory Members

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <returns>Service proxy.</returns>
        public TServiceContract CreateChannel<TServiceContract>()
        {
            return new ChannelFactory<TServiceContract>().CreateChannel();
        }

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="binding">En specifik binding.</param>
        /// <returns>Service proxy.</returns>
        public TServiceContract CreateChannel<TServiceContract>(Binding binding)
        {
            if (binding == null)
            {
                throw new ArgumentNullException("binding");
            }
            return new ChannelFactory<TServiceContract>(binding).CreateChannel();
        }

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="binding">En specifik binding.</param>
        /// <param name="endpointAddress">En specifik endpoint adresse.</param>
        /// <returns>Service proxy.</returns>
        public TServiceContract CreateChannel<TServiceContract>(Binding binding, EndpointAddress endpointAddress)
        {
            if (binding == null)
            {
                throw new ArgumentNullException("binding");
            }
            if (endpointAddress == null)
            {
                throw new ArgumentNullException("endpointAddress");
            }
            return new ChannelFactory<TServiceContract>(binding, endpointAddress).CreateChannel();
        }

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="binding">En specifik binding.</param>
        /// <param name="remoteAddress">En specifik remote adresse.</param>
        /// <returns>Service proxy.</returns>
        public TServiceContract CreateChannel<TServiceContract>(Binding binding, string remoteAddress)
        {
            if (binding == null)
            {
                throw new ArgumentNullException("binding");
            }
            if (string.IsNullOrEmpty(remoteAddress))
            {
                throw new ArgumentNullException("remoteAddress");
            }
            return new ChannelFactory<TServiceContract>(binding, remoteAddress).CreateChannel();
        }

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="serviceEndpoint">En specifik service endpoint.</param>
        /// <returns>Service proxy.</returns>
        public TServiceContract CreateChannel<TServiceContract>(ServiceEndpoint serviceEndpoint)
        {
            if (serviceEndpoint == null)
            {
                throw new ArgumentNullException("serviceEndpoint");
            }
            return new ChannelFactory<TServiceContract>(serviceEndpoint).CreateChannel();
        }

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="endpointConfigurationName">En specifik endpoint konfigurationsnavn.</param>
        /// <returns>Service proxy.</returns>
        public TServiceContract CreateChannel<TServiceContract>(string endpointConfigurationName)
        {
            if (string.IsNullOrEmpty(endpointConfigurationName))
            {
                throw new ArgumentNullException("endpointConfigurationName");
            }
            return new ChannelFactory<TServiceContract>(endpointConfigurationName).CreateChannel();
        }

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="endpointConfigurationName">En specifik endpoint konfigurationsnavn.</param>
        /// <param name="endpointAddress">En specifik endpoint adresse.</param>
        /// <returns>Service proxy.</returns>
        public TServiceContract CreateChannel<TServiceContract>(string endpointConfigurationName, EndpointAddress endpointAddress)
        {
            if (string.IsNullOrEmpty(endpointConfigurationName))
            {
                throw new ArgumentNullException("endpointConfigurationName");
            }
            if (endpointAddress == null)
            {
                throw new ArgumentNullException("endpointAddress");
            }
            return new ChannelFactory<TServiceContract>(endpointConfigurationName, endpointAddress).CreateChannel();
        }

        #endregion
    }
}
