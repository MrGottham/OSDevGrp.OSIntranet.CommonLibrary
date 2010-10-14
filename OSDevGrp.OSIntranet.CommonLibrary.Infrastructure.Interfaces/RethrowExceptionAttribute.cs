using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces
{
    /// <summary>
    /// Attribute til at angive overfor en CommandBus, at en exception 
    /// blot skal rethrowes.
    /// </summary>
    public class RethrowExceptionAttribute : Attribute
    {
        /// <summary>
        /// Danner en attribute, som overfor en CommandBus kan angive,
        /// hvilke exceptions der skal rethrowes.
        /// </summary>
        /// <param name="exceptionTypes"></param>
        public RethrowExceptionAttribute(params Type[] exceptionTypes)
        {
            ExceptionTypes = exceptionTypes;
        }

        /// <summary>
        /// Typer af exceptions, der skal rethowes.
        /// </summary>
        public Type[] ExceptionTypes
        {
            get;
            set;
        }
    }
}
