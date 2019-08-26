using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote; // requried for FindElementBy...() methods


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
    public class GoogleSearch_InlineCommands
    {
        //IWebDriver _webDriver;
        RemoteWebDriver _webDriver;

        [TestInitialize]
        public void Startup()
        {
            string browser = "IE"; // available: "IE" "Chrome" "Firefox"

            // make testing against IE a bit easier: 
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();

            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            ieOptions.IgnoreZoomLevel = true;
            ieOptions.EnableNativeEvents = false;

            switch (browser)
            {
                case "IE":
                    _webDriver = new InternetExplorerDriver(ieOptions);
                    break;
                case "Firefox":
                    _webDriver = new FirefoxDriver();
                    break;
                default:
                    _webDriver = new ChromeDriver();
                    break;
            }

            _webDriver.Manage().Window.Maximize();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

        [TestCleanup]
        public void Shutdown()
        {
            _webDriver.Quit();
        }

        [TestCategory("SeleniumTests")]
        [TestMethod]
        public void GoogleSearch_Returns_MazdaUSA_AsFirstItem()
        {
            // Arrange is taken care of in the TestInitialize method "Startup()"

            // Act
            _webDriver.Navigate().GoToUrl("http://www.google.com"); 
            _webDriver.FindElementByName("q").Clear();
            _webDriver.FindElementByName("q").SendKeys("Mazda");
            _webDriver.FindElementByName("q").Submit();
            var linkText = _webDriver.FindElementById("vn1s0p1c0").Text.Substring(0,9);

            // Assert
            Assert.AreEqual("Mazda USA", linkText);
        }
    }
}
