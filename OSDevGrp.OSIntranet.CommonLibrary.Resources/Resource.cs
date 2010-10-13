using System;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace OSDevGrp.OSIntranet.CommonLibrary.Resources
{
    /// <summary>
    /// Access to resources.
    /// </summary>
    public class Resource
    {
        #region Private variables

        private static readonly ResourceManager ExceptionMessages = new ResourceManager("OSDevGrp.OSIntranet.CommonLibrary.Resources.ExceptionMessages", Assembly.GetExecutingAssembly());

        #endregion

        #region Methods

        /// <summary>
        /// Gets an exception message.
        /// </summary>
        /// <param name="resourceName">Resource name for the exception message.</param>
        /// <returns>Exception message.</returns>
        public static string GetExceptionMessage(ExceptionMessage resourceName)
        {
            return GetExceptionMessage(resourceName, null);
        }

        /// <summary>
        /// Get an exception message.
        /// </summary>
        /// <param name="resourceName">Resource name for the exception message.</param>
        /// <param name="args">Arguments to the exception message.</param>
        /// <returns>Exception message.</returns>
        public static string GetExceptionMessage(ExceptionMessage resourceName, params object[] args)
        {
            try
            {
                var exceptionMessage = ExceptionMessages.GetString(resourceName.ToString());
                if (exceptionMessage == null)
                {
                    throw new ResourceException("Null returned.");
                }
                return args != null ? string.Format(exceptionMessage, args) : exceptionMessage;
            }
            catch (Exception ex)
            {
                throw new ResourceException(
                    string.Format("Couldn't get resourcestring '{0}' using culture '{1}'.", resourceName,
                                  Thread.CurrentThread.CurrentUICulture.Name), ex);
            }
        }

        #endregion
    }
}
