using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Pages
{

    /// <summary>
    /// Class containing unit test cases to User_Page
    /// </summary>
    public class User_Page
    {

        // creating an instance
        #region TestSetup
        public static Index1Model pageModel;
        /// <summary>
        /// Initializing
        /// ILogger to write log messages
        /// </summary>

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<Index1Model>>();

            pageModel = new Index1Model(MockLoggerDirect, TestHelper.ProductService)
            {
            };

        }

        #endregion TestSetup

        /// <summary>
        /// Test to validate onget method.
        /// Returns Products if valid.
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }

        #endregion OnGet
    }
}