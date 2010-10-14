using OSDevGrp.OSIntranet.CommonLibrary.IoC;
using OSDevGrp.OSIntranet.CommonLibrary.Wcf.ChannelFactory;
using NUnit.Framework;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.Wcf
{
    /// <summary>
    /// Tester containerkonfigurationen for WCF komponenter.
    /// </summary>
    [TestFixture]
    public class ConfigurationTests
    {
        /// <summary>
        /// Tester, at ChannelFactory kan resolves.
        /// </summary>
        [Test]
        public void TestAtChannelFactoryKanResolves()
        {
            var container = ContainerFactory.Create();
            var channelFactory = container.Resolve<IChannelFactory>();
            Assert.That(channelFactory, Is.Not.Null);
        }
    }
}
