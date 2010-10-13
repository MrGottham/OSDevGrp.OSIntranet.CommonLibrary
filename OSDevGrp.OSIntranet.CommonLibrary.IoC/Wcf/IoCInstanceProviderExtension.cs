using System;
using System.ServiceModel.Configuration;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Wcf
{
    /// <summary>
    /// Konfiguration af IoCInstanceProvider.
    /// </summary>
    public class IoCInstanceProviderExtension : BehaviorExtensionElement
    {
        /// <summary>
        /// Gets the type of the behavior.
        /// </summary>
        public override Type BehaviorType
        {
            get
            {
                return typeof (IoCInstanceProviderServiceBehavior);
            }
        }

        /// <summary>
        /// Creates a behavior extension on the current configuration settings.
        /// </summary>
        /// <returns>The behavior extension.</returns>
        protected override object CreateBehavior()
        {
            return new IoCInstanceProviderServiceBehavior();
        }
    }
}
