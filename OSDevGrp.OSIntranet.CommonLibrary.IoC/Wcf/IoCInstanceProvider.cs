using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Wcf
{
    /// <summary>
    /// Instanceprovider til WCF, som benytter Inversion of Control container til services.
    /// </summary>
    public class IoCInstanceProvider : IInstanceProvider
    {
        #region Private variables

        private readonly Type _serviceType;

        #endregion

        #region Constructor

        /// <summary>
        /// Default konstruktør.
        /// </summary>
        /// <param name="serviceType">Type på service, der initieres.</param>
        public IoCInstanceProvider(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }
            _serviceType = serviceType;
        }

        #endregion

        #region IInstanceProvider Members

        /// <summary>
        /// Returnerer et serviceobjekt for det specificerede <see cref="T:System.ServiceModel.InstanceContext"/> objekt.
        /// </summary>
        /// <param name="instanceContext">Det aktuelle <see cref="T:System.ServiceModel.InstanceContext"/> objekt.</param>
        /// <param name="message">Besked, der trigger dannelse af serviceobjektet.</param>
        /// <returns>Serviceobjekt.</returns>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var container = ContainerFactory.Create();
            return container.Resolve(_serviceType);
        }

        /// <summary>
        /// Returnerer et serviceobjekt for det specificerede <see cref="T:System.ServiceModel.InstanceContext"/> objekt.
        /// </summary>
        /// <param name="instanceContext">Det aktuelle <see cref="T:System.ServiceModel.InstanceContext"/> objekt.</param>
        /// <returns>Serviceobjekt.</returns>
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        /// <summary>
        /// Kaldes, når et objekt recyckler et serviceobjekt.
        /// </summary>
        /// <param name="instanceContext">>Det aktuelle <see cref="T:System.ServiceModel.InstanceContext"/> objekt.</param>
        /// <param name="instance">Serviceobjekt, der skal recyckles.</param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }

        #endregion
    }
}
