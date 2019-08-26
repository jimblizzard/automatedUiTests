using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTests
{
    public class GSResultsPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "vn1s0p1c0")]
        public IWebElement FirstAdLink { get; set; }

        public GSResultsPage() { }
        public GSResultsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Returns the text from the first ad link on the page
        /// </summary>
        /// <returns></returns>
        public string GetFirstAdLinkText()
        {
            string linkText = FirstAdLink.GetAttribute("text");
            return linkText;
        }
    }
}
