using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Pages.Product
{

    /// <summary>
    /// Class containing unit test cases for delete page
    /// </summary>
    public class DeleteTests
    {

        /// <summary>
        /// Creating instance to the model
        /// </summary>
        #region TestSetup

        public static DeleteModel pageModel;

        /// <summary>
        /// Initializing test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {

            };
        }

        #endregion TestSetup

        /// <summary>
        /// Testing OnGet valid should return all products
        /// </summary>
        #region DeleteData
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            //Arrange

            //Act
            pageModel.OnGet("jenlooper-light");

            //Asset
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("FOOD DONATION Place:Seattle Date:01/10/2023-02/25/2023", pageModel.Product.Title);
        }

        /// <summary>
        /// Testing OnGet for invalid should return false
        /// </summary>
        [Test]
        public void OnGet_Invalid_Should_Return_False()
        {
            //Arrange

            //Act
            pageModel.OnGet("jenlooper");

            //Asset
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        /// <summary>
        /// Testing OnPost invalid model and not valid return to page
        /// </summary>
        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            //Arrange

            //Act
            pageModel.ModelState.AddModelError("-light", "");
            var result = pageModel.OnPost() as ActionResult;

            //Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        /// <summary>
        /// Testing OnPost for valid model return changed page
        /// </summary>
        [Test]
        public void OnPost_Valid_Model_Return_Changed_Page()
        {
            //Arrange

            //Act
            pageModel.ModelState.AddModelError(" ", " ");
            var result = pageModel.OnPost() as ActionResult;

            //Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        /// <summary>
        /// Testing OnPost for valid should return true
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_True()
        {
            //Arrange
            pageModel.Product = new ProductModel
            {
                Title = "COMMUNITY CLEAN-UP",
                Url = "https://scontent-sea1-1.xx.fbcdn.net/v/t39.30808-6/308507659_418691737083122_7593943610641366487_n.png?_nc_cat=101\u0026ccb=1-7\u0026_nc_sid=09cbfe\u0026_nc_ohc=f2NQk2YRKj0AX-tvgVP\u0026_nc_ht=scontent-sea1-1.xx\u0026oh=00_AT-xFOZWzn2no4atDce3-dQe8xmqtQWVdbcK8Pp44s0y2Q\u0026oe=63572779",
                Image = "https://scontent-sea1-1.xx.fbcdn.net/v/t39.30808-6/308507659_418691737083122_7593943610641366487_n.png?_nc_cat=101\u0026ccb=1-7\u0026_nc_sid=09cbfe\u0026_nc_ohc=f2NQk2YRKj0AX-tvgVP\u0026_nc_ht=scontent-sea1-1.xx\u0026oh=00_AT-xFOZWzn2no4atDce3-dQe8xmqtQWVdbcK8Pp44s0y2Q\u0026oe=63572779",
                Description = "Pastel hardware kits complete with custom manufactured pastel alligator clips.",
            };

            //Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            //Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Event"));
        }

        /// <summary>
        /// Testing DeleteData for valid product and valid rating should return true
        /// </summary>
        [Test]
        public void DeleteData_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        #endregion
    }
}