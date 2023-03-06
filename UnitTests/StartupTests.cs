using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;

namespace UnitTests.Pages.Startup
{

    /// <summary>
    /// Class containing unit test cases to Startup
    /// </summary>
    public class StartupTests
    {
        #region TestSetup

        /// <summary>
        /// Test initializing
        /// </summary>

        [SetUp]
        public void TestInitialize()
        {
        }

        /// <summary>
        /// startup class
        /// </summary>
        public class Startup : ContosoCrafts.WebSite.Startup
        {
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        /// <summary>
        /// Testing for startup configure valid default should pass
        /// </summary>
        #region ConfigureServices

        [Test]
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            //Arrange

            //Act
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();

            //Assert
            Assert.IsNotNull(webHost);
        }

        #endregion ConfigureServices

        #region Configure

        /// <summary>
        /// Testing for startup configure valid default should pass
        /// </summary>
        [Test]
        public void Startup_Configure_Valid_Defaut_Should_Pass()
        {
            //Arrange

            //Act
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();

            //Assert
            Assert.IsNotNull(webHost);
        }

        #endregion Configure
    }
}