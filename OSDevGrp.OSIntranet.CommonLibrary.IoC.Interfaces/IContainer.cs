using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces
{
    /// <summary>
    /// Interface for container to Inversion of Control (IoC).
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Resolve object from type.
        /// </summary>
        /// <typeparam name="TType">Type to resolve.</typeparam>
        /// <returns>Resolved object.</returns>
        TType Resolve<TType>();

        /// <summary>
        /// Resolve object based on a key.
        /// </summary>
        /// <typeparam name="TType">Type to resolve.</typeparam>
        /// <param name="key">Key of object to resolve.</param>
        /// <returns>Resolved object.</returns>
        object Resolve<TType>(string key);

        /// <summary>
        /// Resolve object from type. Should only be used in circumstances where 
        /// generic version of method can be used.
        /// </summary>
        /// <param name="type">Type of object to resolve.</param>
        /// <returns>Resolved object.</returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolve object from type supply anonymous type with arguments.
        /// </summary>
        /// <typeparam name="TType">Type to resolve.</typeparam>
        /// <param name="argumentsAsAnonymousType">Anonymous type.</param>
        /// <returns>Resolved object.</returns>
        TType Resolve<TType>(object argumentsAsAnonymousType);

        /// <summary>
        /// Resolve alle objects registrered for a given type. 
        /// </summary>
        /// <typeparam name="TType">Type to resolve.</typeparam>
        /// <returns>Resolved objects.</returns>
        TType[] ResolveAll<TType>();

        /// <summary>
        /// Resolve all objects from type. Should only be used in circumstances 
        /// where generic version of method can be used.
        /// </summary>
        /// <param name="type">Type of object to resolve.</param>
        /// <returns>Resolved objects.</returns>
        Array ResolveAll(Type type);
    }
}
