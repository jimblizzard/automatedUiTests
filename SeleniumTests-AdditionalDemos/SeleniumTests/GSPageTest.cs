using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
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
