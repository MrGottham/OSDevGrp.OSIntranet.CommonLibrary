using System;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.IoC.TestObjects
{
    /// <summary>
    /// An other component that can be used for a test.
    /// </summary>
    internal class SomeOtherComponent : ISomeOtherComponent
    {
        /// <summary>
        /// Creates an other component that can be used for a test.
        /// </summary>
        /// <param name="container">Implementation of a container.</param>
        /// <param name="name">Name.</param>
        public SomeOtherComponent(IContainer container, string name)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
        }
    }
}
