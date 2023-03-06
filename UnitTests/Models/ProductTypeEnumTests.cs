using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UnitTests.Models
{

    /// <summary>
    /// Class containing unit test cases of ProductTypeEnum
    /// </summary>
    internal class ProductTypeEnumTests
    {

        /// <summary>
        /// Initializing test
        /// </summary>
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {

        }

        #endregion TestSetup

        /// <summary>
        /// Testing producttypeenum for displayname for handmadeitems
        /// </summary>       
        [Test]
        public void DisplayName_Valid_Amature_Should_Return_Hand_Made_Items()
        {
            // Arrange
            ProductTypeEnum productTypeEnum = ProductTypeEnum.Amature;
            var target = "Hand Made Items";

            // Act
            var result = ProductTypeEnumExtensions.DisplayName(productTypeEnum);

            //Assert
            Assert.AreEqual(target, result);
        }

        /// <summary>
        /// Testing producttypeenum for displayname for Antiques
        /// </summary>       
        [Test]
        public void DisplayName_Valid_Antique_Should_Return_Antiques()
        {
            // Arrange
            ProductTypeEnum productTypeEnum = ProductTypeEnum.Antique;
            var target = "Antiques";

            // Act
            var result = ProductTypeEnumExtensions.DisplayName(productTypeEnum);

            //Assert
            Assert.AreEqual(target, result);
        }

        /// <summary>
        /// Testing producttypeenum for displayname for Antiques
        /// </summary>        
        [Test]
        public void DisplayName_Valid_Collectable_Should_Return_Collectables()
        {
            // Arrange
            ProductTypeEnum productTypeEnum = ProductTypeEnum.Collectable;
            var target = "Collectables";

            // Act
            var result = ProductTypeEnumExtensions.DisplayName(productTypeEnum);

            //Assert
            Assert.AreEqual(target, result);
        }

        /// <summary>
        /// Testing producttypeenum for displayname for Antiques
        /// </summary>        
        [Test]
        public void DisplayName_Valid_Commercial_Should_Return_Commercial_goods()
        {
            // Arrange
            ProductTypeEnum productTypeEnum = ProductTypeEnum.Commercial;
            var target = "Commercial goods";

            // Act
            var result = ProductTypeEnumExtensions.DisplayName(productTypeEnum);

            //Assert
            Assert.AreEqual(target, result);
        }

        /// <summary>
        /// Testing producttypeenum for displayname for Antiques
        /// </summary>        
        [Test]
        public void DisplayName_Valid_Undefined_Should_Return_Empty_Var()
        {
            // Arrange
            ProductTypeEnum productTypeEnum = ProductTypeEnum.Undefined;
            var target = "";

            // Act
            var result = ProductTypeEnumExtensions.DisplayName(productTypeEnum);

            //Assert
            Assert.AreEqual(target, result);
        }
    }
}