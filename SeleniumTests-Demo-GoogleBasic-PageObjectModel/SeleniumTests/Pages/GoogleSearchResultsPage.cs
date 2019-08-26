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

    public class GoogleSearchResultsPage
    {
        private static IWebDriver _driver;

        By firstAdLink = By.Id("vn1s0p1c0");

        public GoogleSearchResultsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Return the text from the first ad link on the page
        public string GetFirstAdLinkText()
        {
            return _driver.FindElement(firstAdLink).Text;
        }

    }
}
