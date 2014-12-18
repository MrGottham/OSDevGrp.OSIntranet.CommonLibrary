using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using OSDevGrp.OSIntranet.CommonLibrary.Repositories.Interface.Exceptions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.Repositories
{
    /// <summary>
    /// Tester common repository exception.
    /// </summary>
    [TestFixture]
    public class CommonRepositoryExceptionTests
    {
        /// <summary>
        /// Tester, at konstruktøren danner en common repository exception.
        /// </summary>
        [Test]
        public void TestAtConstructorDannerCommonRepositoryEception()
        {
            var fixture = new Fixture();
            var message = fixture.Create<string>();
            var commonRepositoryException = new CommonRepositoryException(message);
            Assert.That(commonRepositoryException, Is.Not.Null);
            Assert.That(commonRepositoryException.Message, Is.Not.Null);
            Assert.That(commonRepositoryException.Message, Is.EqualTo(message));
            Assert.That(commonRepositoryException.InnerException, Is.Null);
        }

        /// <summary>
        /// Tester, at konstruktøren danner en common repository exception med inner exception.
        /// </summary>
        [Test]
        public void TestAtConstructorDannerCommonRepositoryEceptionMedInnerException()
        {
            var fixture = new Fixture();
            var message = fixture.Create<string>();
            var innerException = fixture.Create<Exception>();
            var commonRepositoryException = new CommonRepositoryException(message, innerException);
            Assert.That(commonRepositoryException, Is.Not.Null);
            Assert.That(commonRepositoryException.Message, Is.Not.Null);
            Assert.That(commonRepositoryException.Message, Is.EqualTo(message));
            Assert.That(commonRepositoryException.InnerException, Is.Not.Null);
            Assert.That(commonRepositoryException.InnerException, Is.EqualTo(innerException));
        }

        /// <summary>
        /// Tester, at CommonRepositoryException kan serialiseres og deserialiseres.
        /// </summary>
        [Test]
        public void TestAtCommonRepositoryExceptionKanSerialiseresOgDeserialiseres()
        {
            var fixture = new Fixture();
            var commonRepositoryException = fixture.Create<CommonRepositoryException>();
            Assert.That(commonRepositoryException, Is.Not.Null);

            var memoryStream = new MemoryStream();
            try
            {
                var serializer = new SoapFormatter();
                serializer.Serialize(memoryStream, commonRepositoryException);
                Assert.That(memoryStream.Length, Is.GreaterThan(0));

                memoryStream.Seek(0, SeekOrigin.Begin);
                Assert.That(memoryStream.Position, Is.EqualTo(0));

                var deserializedCommonRepositoryException = (CommonRepositoryException) serializer.Deserialize(memoryStream);
                Assert.That(deserializedCommonRepositoryException, Is.Not.Null);
                Assert.That(deserializedCommonRepositoryException.Message, Is.Not.Null);
                Assert.That(deserializedCommonRepositoryException.Message, Is.EqualTo(commonRepositoryException.Message));
                Assert.That(deserializedCommonRepositoryException.InnerException, Is.EqualTo(commonRepositoryException.InnerException));
            }
            finally
            {
                memoryStream.Close();
            }
        }
    }
}
