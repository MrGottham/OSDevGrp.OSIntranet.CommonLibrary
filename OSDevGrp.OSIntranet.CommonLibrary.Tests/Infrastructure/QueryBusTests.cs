using System;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces.Exceptions;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.Infrastructure
{
    /// <summary>
    /// Tester implementering af en QueryBus.
    /// </summary>
    [TestFixture]
    public class QueryBusTests
    {
        /// <summary>
        /// Tester, at konstruktøren kaster en ArgumentNullException, hvis container er null.
        /// </summary>
        [Test]
        public void TestAtConstructorKasterArgumentNullExceptionHvisContainerErNull()
        {
            Assert.Throws<ArgumentNullException>(() => new QueryBus(null));
        }

        /// <summary>
        /// Tester, at Query kaster en ArgumentNullException, hvis query er null.
        /// </summary>
        [Test]
        public void TestAtQueryKasterArgumentNullExceptionHvisQueryErNull()
        {
            var queryBus = new QueryBus(CreateContainer());
            Assert.Throws<ArgumentNullException>(() => queryBus.Query<TestQuery, Guid>(null));
        }

        /// <summary>
        /// Tester, at Query kaster en QueryBusException, hvis der ikke er registreret en queryhandler.
        /// </summary>
        [Test]
        public void TestAtQueryKasterQueryBusExceptionHvisQueryHandlerIkkeErRegistreret()
        {
            var queryBus = new QueryBus(CreateContainer());
            var query = new TestQueryWithoutQueryHandler();
            Assert.Throws<QueryBusException>(() => queryBus.Query<TestQueryWithoutQueryHandler, Guid>(query));
        }

        /// <summary>
        /// Danner en container, som kan benyttes til test af en QueryBus.
        /// </summary>
        /// <returns>Container til Inversion of Control.</returns>
        private static IContainer CreateContainer()
        {
            var container = MockRepository.GenerateMock<IContainer>();
            return container;
        }
    }
}
