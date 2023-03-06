using Castle.Core.Logging;
using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Pages.Product;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Pages.Product
{

    /// <summary>
    /// Class containing unit test cases to Index page
    /// </summary>
    public class EventTests
    {

        // creating an instance
        #region TestSetup

        public static EventModel pageModel;

        /// <summary>
        /// Test initializing
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new EventModel(TestHelper.ProductService)
            {

            };
        }

        #endregion TestSetup

        /// <summary>
        ///  On making a get call the request should return all the products
        /// </summary>
        #region OnGet
        [Test]
        public void EventModel_OnGet_Valid_Should_Return_Products()
        {
            //Arrange

            //Act
            pageModel.OnGet();

            //Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }

        #endregion OnGet
    }
}