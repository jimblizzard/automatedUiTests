using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTests
{
    public class GSHomePage
    {
        private static IWebDriver _driver;

        // SearchBox element
        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement SearchBox { get; set; }

        public GSHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// NavigateTo - creates the GSHomePage object
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static GSHomePage NavigateTo(IWebDriver driver)
        {
            _driver = driver;
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _driver.Navigate().GoToUrl("http://www.google.com");
            return PageFactory.InitElements<GSHomePage>(_driver); 
        }

        /// <summary>
        /// SearchFor - Executes a search for the given text
        /// and returns the GSResultsPage (search results page)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public GSResultsPage SearchFor(string text)
        {
            SearchBox.SendKeys(text);
            SearchBox.Submit();
            return PageFactory.InitElements<GSResultsPage>(_driver);
        }
    }
}
