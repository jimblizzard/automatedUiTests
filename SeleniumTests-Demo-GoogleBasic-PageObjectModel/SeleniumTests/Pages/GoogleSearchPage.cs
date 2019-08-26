using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

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

    public class GoogleSearchPage
    {
        private static IWebDriver _driver;

        By searchBox = By.Name("q");
        By firstAdLink = By.Id("vn1s0p1c0");


        public GoogleSearchPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl("http://www.google.com");
        }

        public GoogleSearchResultsPage SearchFor(string text)
        {
            setSearchText(text);
            submitSearch();
            return new GoogleSearchResultsPage(_driver);
        }


        // Return the text from the first ad link on the page
        public string GetFirstAdLinkText()
        {
            return _driver.FindElement(firstAdLink).GetAttribute("text");
        }

        void setSearchText(string text)
        {
            _driver.FindElement(searchBox).SendKeys(text);
        }

        void submitSearch()
        {
            _driver.FindElement(searchBox).Submit();
        }

    }
}
