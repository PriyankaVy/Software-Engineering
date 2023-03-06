using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Product.AddRating
{

    /// <summary>
    /// Class containing unit test cases to JsonFileProductService file
    /// </summary>
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        /// <summary>
        /// Test initialize
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        /// <summary>
        /// Testing to check if a invalid product null will return false
        /// </summary>
        #region AddRating
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing AddRating for invalid product empty will return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing AddRating for invalid null data should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Data_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("Does not exist", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing AddRating for invalid negative rating should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Negative_Rating_Should_Return_False()
        {
            // Arrange
            var productID = TestHelper.ProductService.GetAllData().First().Id;

            // Act
            var result = TestHelper.ProductService.AddRating(productID, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing AddRating for Invalid too high rating should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Too_High_Rating_Should_Return_False()
        {
            // Arrange
            var productID = TestHelper.ProductService.GetAllData().First().Id;

            // Act
            var result = TestHelper.ProductService.AddRating(productID, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing AddRating for valid product and valid rating should return true
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
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

        #endregion AddRating

        /// <summary>
        /// Testing typical, valid usage of UpdateData method
        /// </summary>
        [Test]
        public void UpdateData_Valid_Updated_Value_Matches_Should_Return_True()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().FirstOrDefault();
            var data2 = data;
            data2.Title = "Test";

            // Act
            var result = TestHelper.ProductService.UpdateData(data2);

            // Reset
            _ = TestHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual(data2.Title, result.Title);
        }

        /// <summary>
        /// Testing add rating if valid and invalid rating should return false
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_InValid_Rating_Valid_Should_Return_False()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing valid product invalid rating and rating less than zero should return false
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_InValid_Rating_Less_Than_Zero_Valid_Should_Return_False()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing add rating invalid product id should return false
        /// </summary>
        [Test]
        public void AddRating_Invalid_ProductId_Given_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("jenlooper-test12345", 4);

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}