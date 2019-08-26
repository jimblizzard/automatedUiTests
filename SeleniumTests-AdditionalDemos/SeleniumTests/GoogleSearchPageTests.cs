using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTests
{
    [TestClass]
    public class GoogleSearchPageTests
    {
        IWebDriver _driver = new ChromeDriver();

        [TestMethod]
        public void SearchForShoes_ReturnsShoes()
        {
            // arrange
            // act
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _driver.Navigate().GoToUrl("http://www.google.com");

            // create the GoogleSearchPage object
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(_driver);
            PageFactory.InitElements(_driver, googleSearchPage);
            
            // search for shoes
            googleSearchPage.SearchFor("shoes");
            var stats = googleSearchPage.ResultStats.Text;

            // assert
            Assert.IsTrue(stats.Contains("About"), "Result did not includ stats");
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            _driver.Quit();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
        }
    }
}
