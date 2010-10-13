using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces.Exceptions;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces.Windsor;
using OSDevGrp.OSIntranet.CommonLibrary.Resources;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Configuration
{
    /// <summary>
    /// Static class used for reading and validating configuration.
    /// </summary>
    internal static class ConfigurationReader
    {
        #region Private variables

        private const string ConfigurationSectionElementName = "iocConfiguration";
        private const string ContainerConfigurationElementName = "container";
        private const string ConfigurationProvidersElementName = "configurationProviders";

        #endregion

        #region Properties

        /// <summary>
        /// Get the type of container which supporting Inversion of Control.
        /// </summary>
        public static Type ContainerType
        {
            get
            {
                var handler = GetConfigurationSectionHandler();
                if (handler.ContainerConfiguration == null)
                {
                    throw new ContainerConfigurationException(
                        Resource.GetExceptionMessage(ExceptionMessage.CouldNotReadContainerConfiguration,
                                                     ContainerConfigurationElementName, ConfigurationSectionElementName));
                }

                var typeName = handler.ContainerConfiguration.Type;
                ValidateContainerTypeName(typeName);

                return Type.GetType(typeName);
            }
        }

        /// <summary>
        /// Get list of configuration providers.
        /// </summary>
        public static IList<Type> ConfigurationProviders
        {
            get
            {
                var providers = new List<Type>();

                var handler = GetConfigurationSectionHandler();
                foreach (var typeName in
                    from ContainerConfigurationProvider provider in handler.ConfigurationProviders
                    select provider.Type)
                {
                    ValidateProviderTypeName(typeName);
                    providers.Add(Type.GetType(typeName));
                }

                return providers;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the configuration section handler.
        /// </summary>
        /// <returns>Configuration section handler.</returns>
        private static ConfigurationSectionHandler GetConfigurationSectionHandler()
        {
            var configurationSectionHandler =
                ConfigurationManager.GetSection(ConfigurationSectionElementName) as ConfigurationSectionHandler;
            if (configurationSectionHandler == null)
            {
                throw new ContainerConfigurationException(
                    Resource.GetExceptionMessage(ExceptionMessage.ConfigurationSectionCouldNotBeReaded,
                                                 ConfigurationSectionElementName));
            }
            return configurationSectionHandler;
        }

        /// <summary>
        /// Validates that typeName is a container.
        /// </summary>
        /// <param name="typeName">Name of type to validate.</param>
        private static void ValidateContainerTypeName(string typeName)
        {
            try
            {
                ValidateTypeName(typeName);
            }
            catch (Exception ex)
            {
                throw new ContainerConfigurationException(
                    Resource.GetExceptionMessage(ExceptionMessage.WrongConfiguredType, typeName,
                                                 ContainerConfigurationElementName, ConfigurationSectionElementName,
                                                 ex.Message), ex);
            }

            var type = Type.GetType(typeName);
            if (!DoesTypeImplementInterface(type, typeof(IContainer)))
            {
                throw new ContainerConfigurationException(
                    Resource.GetExceptionMessage(ExceptionMessage.ConfiguredTypeDoesNotImplementInterface, typeName,
                                                 ContainerConfigurationElementName, ConfigurationSectionElementName,
                                                 typeof (IContainer)));
            }
        }

        /// <summary>
        /// Validates that typeName is ...
        /// </summary>
        /// <param name="typeName">Name of type to validate.</param>
        private static void ValidateProviderTypeName(string typeName)
        {
            try
            {
                ValidateTypeName(typeName);
            }
            catch (Exception ex)
            {
                throw new ContainerConfigurationException(
                    Resource.GetExceptionMessage(ExceptionMessage.WrongConfiguredType, typeName,
                                                 ConfigurationProvidersElementName, ConfigurationSectionElementName,
                                                 ex.Message), ex);
            }

            var type = Type.GetType(typeName);
            if (!DoesTypeImplementInterface(type, typeof(IConfigurationProvider)))
            {
                throw new ContainerConfigurationException(
                    Resource.GetExceptionMessage(ExceptionMessage.ConfiguredTypeDoesNotImplementInterface, typeName,
                                                 ConfigurationProvidersElementName, ConfigurationSectionElementName,
                                                 typeof (IConfigurationProvider)));
            }
        }

        /// <summary>
        /// Validates a type name.
        /// </summary>
        /// <param name="typeName">Name of type to validate.</param>
        private static void ValidateTypeName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                throw new ContainerConfigurationException(
                    Resource.GetExceptionMessage(ExceptionMessage.TypeNotConfigured));
            }
            if (Type.GetType(typeName) == null)
            {
                throw new ContainerConfigurationException(Resource.GetExceptionMessage(ExceptionMessage.InvalidType,
                                                                                       typeName));
            }
        }

        /// <summary>
        /// Check if the supplied type implements an given interface.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="interfaceType">Interface</param>
        /// <returns>True if the type implements the interface otherwise false.</returns>
        private static bool DoesTypeImplementInterface(Type type, Type interfaceType)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (interfaceType == null)
            {
                throw new ArgumentNullException("interfaceType");
            }
            return type.GetInterfaces().Any(implementedInterface => implementedInterface == interfaceType);
        }

        #endregion
    }
}
