using System;
using Castle.Windsor;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Windsor
{
    /// <summary>
    /// Container for Inversion of Control (IoC).
    /// </summary>
    public class Container : IContainer
    {
        #region Private variables

        private static readonly IWindsorContainer WindsorContainer;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        static Container()
        {
            WindsorContainer = ContainerConfiguration.GetConfiguredInstance();
        }

        #endregion

        #region IContainer Members

        /// <summary>
        /// Resolve object from type.
        /// </summary>
        /// <typeparam name="TType">Type to resolve.</typeparam>
        /// <returns>Resolved object.</returns>
        public TType Resolve<TType>()
        {
            return WindsorContainer.Resolve<TType>();
        }

        /// <summary>
        /// Resolve object based on a key.
        /// </summary>
        /// <typeparam name="TType">Type to resolve.</typeparam>
        /// <param name="key">Key of object to resolve.</param>
        /// <returns>Resolved object.</returns>
        public object Resolve<TType>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            return WindsorContainer.Resolve<TType>(key);
        }

        /// <summary>
        /// Resolve object from type. Should only be used in circumstances where 
        /// generic version of method can be used.
        /// </summary>
        /// <param name="type">Type of object to resolve.</param>
        /// <returns>Resolved object.</returns>
        public object Resolve(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return WindsorContainer.Resolve(type);
        }

        /// <summary>
        /// Resolve object from type supply anonymous type with arguments.
        /// </summary>
        /// <typeparam name="TType">Type to resolve.</typeparam>
        /// <param name="argumentsAsAnonymousType">Anonymous type.</param>
        /// <returns>Resolved object.</returns>
        public TType Resolve<TType>(object argumentsAsAnonymousType)
        {
            if (argumentsAsAnonymousType == null)
            {
                throw new ArgumentNullException("argumentsAsAnonymousType");
            }
            return WindsorContainer.Resolve<TType>(argumentsAsAnonymousType);
        }

        /// <summary>
        /// Resolve alle objects registrered for a given type. 
        /// </summary>
        /// <typeparam name="TType">Type to resolve.</typeparam>
        /// <returns>Resolved objects.</returns>
        public TType[] ResolveAll<TType>()
        {
            return WindsorContainer.ResolveAll<TType>();
        }

        /// <summary>
        /// Resolve all objects from type. Should only be used in circumstances 
        /// where generic version of method can be used.
        /// </summary>
        /// <param name="type">Type of object to resolve.</param>
        /// <returns>Resolved objects.</returns>
        public Array ResolveAll(Type type)
        {
            if (type == null)
            {
                throw new ArgumentException("type");
            }
            return WindsorContainer.ResolveAll(type);
        }

        #endregion
    }
}
