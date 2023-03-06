using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Components;
using System.Net.WebSockets;
using Bunit;

namespace UnitTests.Components
{

    /// <summary>
    /// Class containing unit test cases to ProductList
    /// </summary>
    public class ProductListTests : BunitTestContext
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
        /// Test for ProductList Default Should Return Content
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            //Act
            var page = RenderComponent<ProductList>();

            //Get the cards returned
            var result = page.Markup;

            //Assert
            Assert.AreEqual(true, result.Contains("MEDICAL CAMPS in Christian High school Place:Los Angels Date:01/01/2023-05/01/2023"));
        }

        /// <summary>
        /// Test for Product id Should Return Content
        /// </summary>
        [Test]
        public void SelectProduct_Valid_ID_Educating_Should_Return_Content()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_Educating-Children";

            var page = RenderComponent<ProductList>();

            //Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            //Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            //Act
            button.Click();

            //Get the markup to use for the assert
            var pageMarkup = page.Markup;

            //Assert
            Assert.AreEqual(true, pageMarkup.Contains("We help kids around the world to dream big and reach their goals through better education. We help children and teens in some of the most poverty stricken areas with good education. ."));
        }

        /// <summary>
        /// Test for submit rating for valid id Should increment the count 
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Unstared_Should_Increment_Count_And_Check_Star()
        {
            /*
             This test tests that the SubmitRating will change the voteas well as the Star checked
            Because the star check is a calculation of the ratings,using a record that has no stars and checking one makes it clear what was changed

            The test need to open the page
            Then open the popup on the card
            Then records the states of the count and star check status
            Then check a star
            then check again the state of the count and star check status

             */

            //Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_jenlooper-light";

            var page = RenderComponent<ProductList>();

            //Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            //Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            //Get the markup of the page post the click action
            var buttonMarkup = page.Markup;

            //Get the star Buttons
            var starButtonList = page.FindAll("span");

            //Get the vote count
            //Get the vote count, the list should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            //Get the first star item from the list, it should not be checked
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            //Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            //Act

            //Click the star button
            starButton.Click();

            //Get the markup to use for the assert
            buttonMarkup = page.Markup;

            //Get the star Buttons
            starButtonList = page.FindAll("span");

            //Get the vote count
            //Get the vote count, the list should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            //Get the first star item from the list, it should not be checked
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            //Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            //Assert

            //Confirm that the record has no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }
    }
}