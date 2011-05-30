using System;
using System.Collections.Specialized;
using System.IO;
using OSDevGrp.OSIntranet.CommonLibrary.Repositories.Interface.Exceptions;
using OSDevGrp.OSIntranet.CommonLibrary.Resources;

namespace OSDevGrp.OSIntranet.CommonLibrary.Repositories
{
    /// <summary>
    /// Basisklasse til et konfigurationsrepository.
    /// </summary>
    public abstract class KonfigurationRepositoryBase
    {
        /// <summary>
        /// Henter og returnerer en strengværdi for en given nøgle i applikationskonfigurationer.
        /// </summary>
        /// <param name="applicationSettings">Navn på nøgle i applikationskonfigurationer.</param>
        /// <param name="keyName">Navn på nøgle i applikationskonfigurationer.</param>
        /// <returns>Strengværdi.</returns>
        protected virtual string GetStringFromApplicationSettings(NameValueCollection applicationSettings, string keyName)
        {
            return GetStringFromApplicationSettings(applicationSettings, keyName, false);
        }

        /// <summary>
        /// Henter og returnerer en strengværdi for en given nøgle i applikationskonfigurationer.
        /// </summary>
        /// <param name="applicationSettings">Applikationskonfigurationer.</param>
        /// <param name="keyName">Navn på nøgle i applikationskonfigurationer.</param>
        /// <param name="allowEmptyValue">Angivelse af, om value må være tom.</param>
        /// <returns>Strengværdi.</returns>
        protected virtual string GetStringFromApplicationSettings(NameValueCollection applicationSettings, string keyName, bool allowEmptyValue)
        {
            if (applicationSettings == null)
            {
                throw new ArgumentNullException("applicationSettings");
            }
            if (keyName == null)
            {
                throw new ArgumentNullException("keyName");
            }
            var value = applicationSettings[keyName];
            if (value == null)
            {
                var message = Resource.GetExceptionMessage(ExceptionMessage.MissingApplicationSetting, keyName);
                throw new CommonRepositoryException(message);
            }
            if (value.CompareTo(string.Empty) == 0 && !allowEmptyValue)
            {
                var message = Resource.GetExceptionMessage(ExceptionMessage.IllegalValueForApplicationSetting, value, keyName);
                throw new CommonRepositoryException(message);
            }
            return value;
        }

        /// <summary>
        /// Henter og returnerer en numerisk værdi for en given nøgle i applikationskonfigurationer.
        /// </summary>
        /// <param name="applicationSettings">Applikationskonfigurationer.</param>
        /// /// <param name="keyName">Navn på nøgle i applikationskonfigurationer.</param>
        /// <returns>Numerisk værdi.</returns>
        protected virtual int GetIntFromApplicationSettings(NameValueCollection applicationSettings, string keyName)
        {
            var value = GetStringFromApplicationSettings(applicationSettings, keyName, false);
            try
            {
                return int.Parse(value);
            }
            catch (Exception ex)
            {
                var message = Resource.GetExceptionMessage(ExceptionMessage.IllegalValueForApplicationSetting, value,
                                                           keyName);
                throw new CommonRepositoryException(message, ex);
            }
        }

        /// <summary>
        /// Henter og returnerer en bolsk værdi for en given nøgle i applikationskonfigurationer.
        /// </summary>
        /// <param name="applicationSettings">Applikationskonfigurationer.</param>
        /// <param name="keyName">Navn på nøgle i applikationskonfigurationer.</param>
        /// <returns>Bolsk værdi.</returns>
        protected virtual bool GetBoolFromApplicationSettings(NameValueCollection applicationSettings, string keyName)
        {
            var value = GetStringFromApplicationSettings(applicationSettings, keyName, false);
            try
            {
                return bool.Parse(value);
            }
            catch (Exception ex)
            {
                var message = Resource.GetExceptionMessage(ExceptionMessage.IllegalValueForApplicationSetting, value,
                                                           keyName);
                throw new CommonRepositoryException(message, ex);
            }
        }

        /// <summary>
        /// Henter og returnerer en pathværdi for en given nøgle i applikationskonfigurationer.
        /// </summary>
        /// <param name="applicationSettings">Applikationskonfigurationer.</param>
        /// <param name="keyName">Navn på nøgle i applikationskonfigurationer.</param>
        /// <returns>Pathværdi.</returns>
        protected virtual DirectoryInfo GetPathFromApplicationSettings(NameValueCollection applicationSettings, string keyName)
        {
            return GetPathFromApplicationSettings(applicationSettings, keyName, false);
        }

        /// <summary>
        /// Henter og returnerer en pathværdi for en given nøgle i applikationskonfigurationer.
        /// </summary>
        /// <param name="applicationSettings">Applikationskonfigurationer.</param>
        /// <param name="keyName">Navn på nøgle i applikationskonfigurationer.</param>
        /// <param name="allowEmptyValue">Angivelse af, om value må være tom.</param>
        /// <returns>Pathværdi.</returns>
        protected virtual DirectoryInfo GetPathFromApplicationSettings(NameValueCollection applicationSettings, string keyName, bool allowEmptyValue)
        {
            var value = GetStringFromApplicationSettings(applicationSettings, keyName, allowEmptyValue);
            if (value.CompareTo(string.Empty) == 0 && allowEmptyValue)
            {
                return null;
            }
            var directoryInfo = new DirectoryInfo(Environment.ExpandEnvironmentVariables(value));
            if (!directoryInfo.Exists)
            {
                var message = Resource.GetExceptionMessage(ExceptionMessage.PathInApplicationSettingsDontExists,
                                                           directoryInfo.FullName, keyName);
                throw new CommonRepositoryException(message);
            }
            return directoryInfo;
        }
    }
}
