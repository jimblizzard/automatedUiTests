using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTests
{
    public class CustomBy : By
    {
        /// <summary>
        /// CustomBy extension for By.  Uses a CssSelector to find tags with data-automate as the attibute.  Expects a value assigned to the tag to be entered
        /// </summary>
        /// <param name="customByString"></param>
        public CustomBy(string customByString)
        {
            FindElementMethod = context =>
            {
                IWebElement mockElement = GSPageTestCustomHow.Driver.FindElement(CssSelector("[data-automate=\"" + customByString + "\"]"));
                return mockElement;
            };
        }
        /// <summary>
        /// Custom By statement for specific attribute to be specified.  Extends CssSelector
        /// </summary>
        /// <param name="tagname">attribute to search for</param>
        /// <param name="value">value to search for</param>
        /// <returns></returns>
        public static By HtmlTag(string tagname, string value)
        {
            return CssSelector("[" + tagname + "=\"" + value + "\"]");
        }
    }

    [TestClass]
    public class GSPageTestCustomHow
    {
        public static IWebDriver Driver { get; set; }

        [FindsBy(How = How.Custom, Using = "Home", CustomFinderType = typeof(CustomBy))]
        protected internal IWebElement TestDiv { get; set; }


        [TestInitialize]
        public void Setup()
        {
            Driver = new InternetExplorerDriver();
            Driver.Navigate().GoToUrl("data:text/html,<div data-automate=\"Home\">Home</div>");
        }


        [TestMethod]
        public void ByCustomTag()
        {
            //This is the Page Factory implementation using the FindsBy above
            PageFactory.InitElements(Driver, this);
            Console.WriteLine("-> By : data-automate Value (PageFactory Object) = " + TestDiv.GetAttribute("data-automate"));
            Assert.AreEqual("Home", TestDiv.GetAttribute("data-automate"));

            //These are standard methods of obtaining the method using the standard By and CustomBy method
            var divByValue = Driver.FindElement(CustomBy.HtmlTag("data-automate", "Home"));
            var divByCss = Driver.FindElement(By.CssSelector("[data-automate=\"Home\"]"));
            Console.WriteLine("-> By : data-automate Objects Comparison");
            Assert.AreEqual(divByCss, divByValue);
            Console.WriteLine("-> By : data-automate Value (FindElement CustomBy)= " + TestDiv.GetAttribute("data-automate"));
            Assert.AreEqual("Home", divByValue.Text);
            Console.WriteLine("-> By : data-automate Value (FindElement By.CssSelector) = " + divByValue.Text);
            Assert.AreEqual("Home", divByValue.GetAttribute("data-automate"));
        }


        [TestCleanup]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
