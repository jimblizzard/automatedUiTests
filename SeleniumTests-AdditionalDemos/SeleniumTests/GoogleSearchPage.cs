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
