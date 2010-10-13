using OSDevGrp.OSIntranet.CommonLibrary.Resources;
using NUnit.Framework;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.Resources
{
    /// <summary>
    /// Tester klasses Resource.
    /// </summary>
    [TestFixture]
    public class ResourceTests
    {
        /// <summary>
        /// Tester, at GetExceptionMessage uden argnumenter returnerer en exception message.
        /// </summary>
        [Test]
        public void TestAtGetExceptionMessageUdenArgumenterReturnererExceptionMessage()
        {
            var exceptionMessage = Resource.GetExceptionMessage(ExceptionMessage.TypeNotConfigured);
            Assert.That(exceptionMessage, Is.Not.Null);
            Assert.That(exceptionMessage.Length, Is.GreaterThan(0));
        }

        /// <summary>
        /// Tester, at GetExceptionMessage med argumenter returnerer en exception message.
        /// </summary>
        [Test]
        public void TestAtGetExceptionMessageMedArgumenterReturnererExceptionMessage()
        {
            var exceptionMessage = Resource.GetExceptionMessage(ExceptionMessage.NoConfigurationProviderFoundWithKey,
                                                                "container");
            Assert.That(exceptionMessage, Is.Not.Null);
            Assert.That(exceptionMessage.Length, Is.GreaterThan(0));
        }
    }
}
