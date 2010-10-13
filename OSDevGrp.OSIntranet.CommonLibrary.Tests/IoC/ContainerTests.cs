using System.Collections;
using NUnit.Framework;
using OSDevGrp.OSIntranet.CommonLibrary.IoC;
using OSDevGrp.OSIntranet.CommonLibrary.Tests.IoC.TestObjects;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.IoC
{
    /// <summary>
    /// Test af container til Inversion of Control.
    /// </summary>
    [TestFixture]
    public class ContainerTests
    {
        /// <summary>
        /// Tester, at komponenter i konfigurationsproviders kan resolves.
        /// </summary>
        [Test]
        public void TestAtComponentsInProvidersKanResolves()
        {
            var container = ContainerFactory.Create();

            var enumerable = container.Resolve<IEnumerable>();
            Assert.That(enumerable, Is.Not.Null);

            var someComponent = container.Resolve<ISomeComponent>();
            Assert.That(someComponent, Is.Not.Null);
        }

        /// <summary>
        /// Tester, at flere komponenter med samme interface kan resolves.
        /// </summary>
        [Test]
        public void TestAtListOfComponentMedSammeInterfaceKanResolves()
        {
            var container = ContainerFactory.Create();

            var enumerable = container.ResolveAll<IEnumerable>();
            Assert.That(enumerable, Is.Not.Null);
            Assert.That(enumerable.Length, Is.EqualTo(2));
        }
    }
}
