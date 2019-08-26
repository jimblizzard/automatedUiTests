using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Interactions;

// test PartsUnlimited sample app website using Selenium
// You can get the Parts Unlimited sample app source code from
// https://github.com/Microsoft/PartsUnlimited 


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
    public class SeleniumTest2
    {
        private string baseURL = "http://www.partsunlimited.com";
        private RemoteWebDriver driver;
        private string browser;
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Selenium")]
        [Priority(1)]
        [Owner("Me")]

        public void PartsUHoverTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            driver.Navigate().GoToUrl(this.baseURL);

            // NOTE: The github image in the upper left of the 
            // screen covers most of the Brakes link element. 
            // Very poor design, which makes this part of the 
            // UI very fragile and very difficult to test. 

            // click the link to go to Lighting page. Many
            // ways to find the element. . . 
            // One is by using xpath
            driver.FindElementByXPath("/html/body/header/nav/div[2]/div/div/ul/li[2]/a").Click();
            // Another is by using the link text
            //driver.FindElementByLinkText("/Store/Browse?CategoryId=2").Click();

            // should be on the Lighting page... let's verify that
            var lighting = driver.FindElementByXPath("/html/body/div[1]/section/h2").Text;
            Assert.AreEqual(lighting, "Lighting", "Should be on the lighting page");

            // let's hover over the first item. 
            Actions action = new Actions(driver);
            IWebElement firstItem = driver.FindElementByXPath("/html/body/div[1]/section/div/div[1]/div/a/div[1]");
            action.MoveToElement(firstItem).Perform();

            // wait a moment to give the hover time to act
            System.Threading.Thread.Sleep(1000);

            //  "shop now" and should be visible when hovering
            var shopNowDisplayStatus = driver.FindElementByXPath("/html/body/div[1]/section/div/div[1]/div/a/div[1]/div[3]/div[2]/span[2]").Displayed;
            Assert.IsTrue(shopNowDisplayStatus, "shop now should be visible");

            System.Threading.Thread.Sleep(3000);
            //do other Selenium things here!
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
        }
    }
}
