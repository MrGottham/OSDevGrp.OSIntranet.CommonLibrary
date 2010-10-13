using NUnit.Framework;
using OSDevGrp.OSIntranet.CommonLibrary.IoC;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.IoC
{
    /// <summary>
    /// Tester klassen ContainerFactory.
    /// </summary>
    [TestFixture]
    public class ContainerFactoryTests
    {
        /// <summary>
        /// Tester, at ContainerFactory danner en instans af containeren.
        /// </summary>
        [Test]
        public void TestAtContainerFactoryDannerEnInstansAfContaineren()
        {
            var container = ContainerFactory.Create();
            Assert.That(container, Is.Not.Null);
        }
    }
}
