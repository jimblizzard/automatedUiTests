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
