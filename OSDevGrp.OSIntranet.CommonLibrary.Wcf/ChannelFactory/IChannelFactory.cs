using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace OSDevGrp.OSIntranet.CommonLibrary.Wcf.ChannelFactory
{
    /// <summary>
    /// Interface til en custom channel factory.
    /// </summary>
    public interface IChannelFactory
    {
        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <returns>Service proxy.</returns>
        TServiceContract CreateChannel<TServiceContract>();

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="binding">En specifik binding.</param>
        /// <returns>Service proxy.</returns>
        TServiceContract CreateChannel<TServiceContract>(Binding binding);

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="binding">En specifik binding.</param>
        /// <param name="endpointAddress">En specifik endpoint adresse.</param>
        /// <returns>Service proxy.</returns>
        TServiceContract CreateChannel<TServiceContract>(Binding binding, EndpointAddress endpointAddress);

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="binding">En specifik binding.</param>
        /// <param name="remoteAddress">En specifik remote adresse.</param>
        /// <returns>Service proxy.</returns>
        TServiceContract CreateChannel<TServiceContract>(Binding binding, string remoteAddress);

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="serviceEndpoint">En specifik service endpoint.</param>
        /// <returns>Service proxy.</returns>
        TServiceContract CreateChannel<TServiceContract>(ServiceEndpoint serviceEndpoint);

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="endpointConfigurationName">En specifik endpoint konfigurationsnavn.</param>
        /// <returns>Service proxy.</returns>
        TServiceContract CreateChannel<TServiceContract>(string endpointConfigurationName);

        /// <summary>
        /// Danner en service proxy.
        /// </summary>
        /// <typeparam name="TServiceContract">Typen af serviceskontrakten, som proxyen skal implementerer.</typeparam>
        /// <param name="endpointConfigurationName">En specifik endpoint konfigurationsnavn.</param>
        /// <param name="endpointAddress">En specifik endpoint adresse.</param>
        /// <returns>Service proxy.</returns>
        TServiceContract CreateChannel<TServiceContract>(string endpointConfigurationName, EndpointAddress endpointAddress);
    }
}
