using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumTests
{
    public class GoogleSearchPage
    {
        private IWebDriver _driver;

        // SearchBox element
        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement SearchBox { get; set; }

        // ResultStats element
        [FindsBy(How = How.Id, Using = "resultStats")]
        public IWebElement ResultStats { get; set; }

        public GoogleSearchPage() { }

        public GoogleSearchPage(IWebDriver webDriver)
        {
            _driver = webDriver;

            if (!_driver.Url.Contains("https://www.google.com/?gws_rd=ssl"))
            {
                throw new StaleElementReferenceException("This is not the google search page");
            }

            PageFactory.InitElements(_driver, this);
        }

        /// <summary>
        /// Search for the specified text
        /// </summary>
        /// <param name="text"></param>
        public void SearchFor(string text)
        {
            SearchBox.SendKeys(text);
            SearchBox.Submit();
        }
    }
}
