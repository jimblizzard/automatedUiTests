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
    [TestClass]
    public class GSPageTests
    {
        IWebDriver _driver;

        [TestInitialize]
        public void SetThingsUp()
        {
            string browser = "Chrome"; // available: "IE" "Chrome" "Firefox"

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
        }

        [TestCategory("Selenium")]
        [TestMethod]
        public void GoogleSearchResults_ReturnsMazdaUSA_AsFirstItem_WhenMazdaIsSearched()
        {
            // Arrange
            
            // Act
            GSHomePage homePage = GSHomePage.NavigateTo(_driver);
            GSResultsPage resultsPage = homePage.SearchFor("Mazda");

            string linkText = resultsPage.GetFirstAdLinkText().Substring(0,12);

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
