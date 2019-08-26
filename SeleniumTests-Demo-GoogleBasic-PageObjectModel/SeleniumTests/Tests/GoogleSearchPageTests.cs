using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;


// DISCLAIMER
//
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.


namespace SeleniumTests
{
    //
    // This sample uses the Page Object Model pattern 
    //

    [TestClass]
    public class GoogleSearchPageTests
    {
        IWebDriver _driver;

        [TestInitialize]
        public void SetThingsUp()
        {
            string browser = "Firefox"; // available: "IE" "Chrome" "Firefox"

            switch (browser)
            {
                case "IE":
                    _driver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    _driver = new FirefoxDriver();
                    break;
                default:
                    _driver = new ChromeDriver();
                    break;
            }

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

        [TestCategory("Selenium")]
        [TestMethod]
        public void GoogleSearchResults_ReturnsMazdaUSA_AsFirstItem_WhenMazdaIsSearched()
        {
            // Arrange
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(_driver);

            // Act
            GoogleSearchResultsPage searchResultsPage = googleSearchPage.SearchFor("Mazda");
            
            string linkText = searchResultsPage.GetFirstAdLinkText().Substring(0,12);

            // Assert
            Assert.AreEqual("Mazdausa.com", linkText);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            _driver.Quit();
        }

    }
}
