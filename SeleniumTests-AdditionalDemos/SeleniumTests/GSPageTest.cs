using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTests
{
    [TestClass]
    public class GSPageTest
    {
        //IWebDriver _driver = new ChromeDriver();
        IWebDriver _driver = new InternetExplorerDriver();
        
        [TestMethod]
        public void GoogleSearchResults_ReturnsMazdaUSA_AsFirstItem_WhenMazdaIsSearched()
        {
            GSHomePage homepage = GSHomePage.NavigateTo(_driver);
            GSResultsPage searchresultspage = homepage.SearchFor("Mazda");
            string linkText = searchresultspage.GetFirstAdLinkText().Substring(0,18);
            Assert.AreEqual("Mazda USA Official", linkText);
        }

        //[TestCleanup()]
        public void MyTestCleanup()
        {
            _driver.Quit();
        }

    }
}
