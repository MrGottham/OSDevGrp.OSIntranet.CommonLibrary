using System;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using OSDevGrp.OSIntranet.CommonLibrary.Repositories;
using OSDevGrp.OSIntranet.CommonLibrary.Repositories.Interface.Exceptions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.Repositories
{
    /// <summary>
    /// Tester basisklasse til et konfigurationsrepository.
    /// </summary>
    public class KonfigurationRepositoryBaseTests
    {
        /// <summary>
        /// Egen klasse til test af basisklasse for et konfigurationsrepository.
        /// </summary>
        private class MyKonfigurationRepository : KonfigurationRepositoryBase
        {
        }

        /// <summary>
        /// Tester, at KonfigurationRepositoryBase kan initieres.
        /// </summary>
        [Test]
        public void TestAtKonfigurationRepositoryBaseKanInitieres()
        {
            var repository = new MyKonfigurationRepository();
            Assert.That(repository,Is.Not.Null);
        }

        /// <summary>
        /// Tester, at GetStringFromApplicationSettings henter værdi for en nøgle i applikationskonfigurationer.
        /// </summary>
        [Test]
        public void TestAtGetStringFromApplicationSettingsHenterValueForKeyName()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetStringFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                        CallingConventions.Any,
                                                        new[] {typeof (NameValueCollection), typeof (string)}, null);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var value = fixture.Create<string>();
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, value}
                                          };
            var returnedValue = method.Invoke(repository, new object[] {applicationSettings, keyName});
            Assert.That(returnedValue, Is.Not.Null);
            Assert.That(returnedValue, Is.EqualTo(value));
        }

        /// <summary>
        /// Tester, at GetStringFromApplicationSettings henter en tom værdi for en nøgle i applikationskonfigurationer.
        /// </summary>
        [Test]
        public void TestAtGetStringFromApplicationSettingsHenterEmptyValueForKeyName()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetStringFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                        CallingConventions.Any,
                                                        new[]
                                                            {
                                                                typeof (NameValueCollection), typeof (string),
                                                                typeof (bool)
                                                            }, null);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, string.Empty}
                                          };
            var returnedValue = method.Invoke(repository, new object[] {applicationSettings, keyName, true});
            Assert.That(returnedValue, Is.Not.Null);
            Assert.That(returnedValue, Is.Empty);
        }

        /// <summary>
        /// Tester, at GetStringFromApplicationSettings kaster en ArgumentNullException, hvis applikationskonfigurationer er null.
        /// </summary>
        [Test]
        public void TestAtGetStringFromApplicationSettingsKasterArgumentNullExceptionHvisApplicationSettingsErNull()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetStringFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                        CallingConventions.Any,
                                                        new[] {typeof (NameValueCollection), typeof (string)}, null);
            Assert.That(method, Is.Not.Null);

            Assert.That(
                Assert.Throws<TargetInvocationException>(() => method.Invoke(repository, new object[] {null, null})).
                    InnerException, Is.TypeOf(typeof (ArgumentNullException)));
        }

        /// <summary>
        /// Tester, at GetStringFromApplicationSettings kaster en ArgumentNullException, hvis navnet på nøglen er null.
        /// </summary>
        [Test]
        public void TestAtGetStringFromApplicationSettingsKasterArgumentNullExceptionHvisKeyNameErNull()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetStringFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                        CallingConventions.Any,
                                                        new[] {typeof (NameValueCollection), typeof (string)}, null);
            Assert.That(method, Is.Not.Null);

            var applicationSettings = fixture.Create<NameValueCollection>();
            Assert.That(
                Assert.Throws<TargetInvocationException>(
                    () => method.Invoke(repository, new object[] {applicationSettings, null})).InnerException,
                Is.TypeOf(typeof (ArgumentNullException)));
        }

        /// <summary>
        /// Tester, at GetStringFromApplicationSettings kaster en CommonRepositoryException, hvis nøglen ikke findes i applikationskonfigurationer.
        /// </summary>
        [Test]
        public void TestAtGetStringFromApplicationSettingsKasterCommonRepositoryExceptionHvisKeyNameIkkeFindesIApplicationSettings()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetStringFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                        CallingConventions.Any,
                                                        new[] {typeof (NameValueCollection), typeof (string)}, null);
            Assert.That(method, Is.Not.Null);

            var applicationSettings = fixture.Create<NameValueCollection>();
            var keyName = fixture.Create<string>();
            Assert.That(
                Assert.Throws<TargetInvocationException>(
                    () => method.Invoke(repository, new object[] {applicationSettings, keyName})).InnerException,
                Is.TypeOf(typeof (CommonRepositoryException)));
        }

        /// <summary>
        /// Tester, at GetStringFromApplicationSettings kaster en CommonRepositoryException, hvis værdien for nøglen er tom.
        /// </summary>
        [Test]
        public void TestAtGetStringFromApplicationSettingsKasterCommonRepositoryExceptionHvisValueForKeyNameErEmpty()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetStringFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                        CallingConventions.Any,
                                                        new[]
                                                            {
                                                                typeof (NameValueCollection), typeof (string),
                                                                typeof (bool)
                                                            }, null);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, string.Empty}
                                          };
            Assert.That(
                Assert.Throws<TargetInvocationException>(
                    () => method.Invoke(repository, new object[] {applicationSettings, keyName, false})).InnerException,
                Is.TypeOf(typeof (CommonRepositoryException)));
        }

        /// <summary>
        /// Tester, at GetIntFromApplicationSettings henter værdi for nøgle i applikationskonfigurationer.
        /// </summary>
        [Test]
        public void TestAtGetIntFromApplicationSettingsHenterVærdiForKeyName()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetIntFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var value = fixture.Create<int>();
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, value.ToString()}
                                          };
            var returnValued = method.Invoke(repository, new object[] {applicationSettings, keyName});
            Assert.That(returnValued, Is.EqualTo(value));
        }

        /// <summary>
        /// Tester, at GetIntFromApplicationSettings kaster en CommonRepositoryException, hvis værdi ikke kan parses.
        /// </summary>
        [Test]
        public void TestAtGetIntFromApplicationSettingsKasterCommonRepositoryExceptionHvisVærdiIkkeKanParses()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetIntFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var value = fixture.Create<string>();
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, value}
                                          };
            Assert.That(
                Assert.Throws<TargetInvocationException>(
                    () => method.Invoke(repository, new object[] {applicationSettings, keyName})).InnerException,
                Is.TypeOf(typeof (CommonRepositoryException)));
        }

        /// <summary>
        /// Tester, at GetBoolFromApplicationSettings henter værdi for nøgle i applikationskonfigurationer.
        /// </summary>
        [Test]
        public void TestAtGetBoolFromApplicationSettingsHenterVærdiForKeyName()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetBoolFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var value = fixture.Create<bool>();
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, value.ToString()}
                                          };
            var returnValued = method.Invoke(repository, new object[] { applicationSettings, keyName });
            Assert.That(returnValued, Is.EqualTo(value));
        }

        /// <summary>
        /// Tester, at GetBoolFromApplicationSettings kaster en CommonRepositoryException, hvis værdi ikke kan parses.
        /// </summary>
        [Test]
        public void TestAtGetBoolFromApplicationSettingsKasterCommonRepositoryExceptionHvisVærdiIkkeKanParses()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetBoolFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var value = fixture.Create<string>();
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, value}
                                          };
            Assert.That(
                Assert.Throws<TargetInvocationException>(
                    () => method.Invoke(repository, new object[] { applicationSettings, keyName })).InnerException,
                Is.TypeOf(typeof(CommonRepositoryException)));
        }

        /// <summary>
        /// Tester, at GetPathFromApplicationSettings henter værdi for nøgle i applikationskonfigurationer.
        /// </summary>
        [Test]
        public void TestAtGetPathFromApplicationSettingsHenterVærdiForKeyName()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetPathFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                        CallingConventions.Any,
                                                        new[] {typeof (NameValueCollection), typeof (string)}, null);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var value = Environment.CurrentDirectory;
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, value}
                                          };
            var returnValued = method.Invoke(repository, new object[] {applicationSettings, keyName});
            Assert.That(returnValued, Is.Not.Null);
            Assert.That(returnValued, Is.TypeOf(typeof (DirectoryInfo)));
            Assert.That(((DirectoryInfo) returnValued).FullName, Is.EqualTo(value));
        }

        /// <summary>
        /// Tester, at GetPathFromApplicationSettings henter værdi med environment variabel for nøgle i applikationskonfigurationer.
        /// </summary>
        [Test]
        public void TestAtGetPathFromApplicationSettingsHenterVærdiMedEnvironmentVariabelForKeyName()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetPathFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                        CallingConventions.Any,
                                                        new[] {typeof (NameValueCollection), typeof (string)}, null);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, "%WinDir%"}
                                          };
            var returnValued = method.Invoke(repository, new object[] {applicationSettings, keyName});
            Assert.That(returnValued, Is.Not.Null);
            Assert.That(returnValued, Is.TypeOf(typeof (DirectoryInfo)));
            Assert.That(((DirectoryInfo) returnValued).Exists, Is.True);
        }

        /// <summary>
        /// Tester, at GetPathFromApplicationSettings returnerer null, hvis værdi for nøglen er tom.
        /// </summary>
        [Test]
        public void TestAtGetPathFromApplicationSettingsReturnererNullHvisValueErEmpty()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetPathFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                        CallingConventions.Any,
                                                        new[]
                                                            {
                                                                typeof (NameValueCollection), typeof (string),
                                                                typeof (bool)
                                                            }, null);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var value = string.Empty;
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, value}
                                          };
            var returnValued = method.Invoke(repository, new object[] { applicationSettings, keyName, true });
            Assert.That(returnValued, Is.Null);
        }

        /// <summary>
        /// Tester, at GetPathFromApplicationSettings kaster en CommonRepositoryException, hvis path ikke eksisterer.
        /// </summary>
        [Test]
        public void TestAtGetPathFromApplicationSettingsKasterCommonRepositoryExceptionHvisPathIkkeEksisterer()
        {
            var fixture = new Fixture();
            var repository = fixture.Create<MyKonfigurationRepository>();

            var method = repository.GetType().GetMethod("GetPathFromApplicationSettings",
                                                        BindingFlags.Instance | BindingFlags.NonPublic, null,
                                                        CallingConventions.Any,
                                                        new[] {typeof (NameValueCollection), typeof (string)}, null);
            Assert.That(method, Is.Not.Null);

            var keyName = fixture.Create<string>();
            var value = fixture.Create<string>();
            var applicationSettings = new NameValueCollection
                                          {
                                              {keyName, value}
                                          };
            Assert.That(
                Assert.Throws<TargetInvocationException>(
                    () => method.Invoke(repository, new object[] {applicationSettings, keyName})).InnerException,
                Is.TypeOf(typeof (CommonRepositoryException)));
        }
    }
}
