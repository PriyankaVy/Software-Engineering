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
    /// Class that has unit test cases related to Comment model
    /// </summary>
    public class CommentModelTests
    {

        #region TestSetup

        /// <summary>
        /// Initializing test
        /// </summary>        
        [SetUp]
        public void TestInitialize()
        {

        }

        #endregion TestSetup

        /// <summary>
        /// Test case to validate that on valid activity a valid comment is returned
        /// </summary>
        #region OnGet

        [Test]
        public void Get_Comment_Valid_Model_Should_Return_Comment()
        {
            //Arrange
            CommentModel commentModel = new CommentModel();
            String target = "comment";

            // Act
            commentModel.Comment = target;

            // Assert
            Assert.AreEqual(target, commentModel.Comment);
        }

        /// <summary>
        /// Test case to validate that on valid activity a valid ID is returned
        /// </summary>       
        [Test]
        public void Set_Id_Valid_Model_Should_Set_Id()
        {
            //Arrange
            CommentModel commentModel = new CommentModel();
            String target = "1";

            // Act
            commentModel.Id = target;

            // Assert
            Assert.AreEqual(target, commentModel.Id);
        }

        #endregion OnGet
    }
}