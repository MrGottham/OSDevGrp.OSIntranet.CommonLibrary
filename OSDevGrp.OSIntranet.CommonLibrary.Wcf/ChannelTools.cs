using System;
using System.ServiceModel;

namespace OSDevGrp.OSIntranet.CommonLibrary.Wcf
{
    /// <summary>
    /// Værktøjer til at arbejde med WCF channels.
    /// </summary>
    public static class ChannelTools
    {
        /// <summary>
        /// Lukker en channel korrekt, hvilket vil sige, hvis channel
        /// er åben, bliver den lukket ellers bliver den aborted.
        /// </summary>
        /// <param name="channel">Channel.</param>
        public static void CloseChannel(object channel)
        {
            if (channel == null)
            {
                throw new ArgumentNullException("channel");
            }
            CloseChannel((ICommunicationObject) channel);
        }

        /// <summary>
        /// Lukker en channel korrekt, hvilket vil sige, hvis channel
        /// er åben, bliver den lukket ellers bliver den aborted.
        /// </summary>
        /// <param name="communicationObject">Channel.</param>
        public static void CloseChannel(ICommunicationObject communicationObject)
        {
            if (communicationObject == null)
            {
                throw new ArgumentNullException("communicationObject");
            }
            if (communicationObject.State == CommunicationState.Created ||
                communicationObject.State == CommunicationState.Opened)
            {
                communicationObject.Close();
            }
            else
            {
                communicationObject.Abort();
            }
        }
    }
}
