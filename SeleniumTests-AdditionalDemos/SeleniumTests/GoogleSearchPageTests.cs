using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
