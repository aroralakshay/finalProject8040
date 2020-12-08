
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTest
{
    [TestFixture]
    public class WebsiteTests
    {
        [Test]

        //This test case will be verifying add functionality
        public void Test_Add_Sell()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://34.219.12.221:3000/sell";

            chromeDriver.FindElement(By.LinkText("New Customer")).Click();
            int beforAddCount = (int)chromeDriver.FindElements(By.XPath("//table/tbody/tr"))?.Count;
            chromeDriver.FindElement(By.Id("name")).SendKeys("car1");
            chromeDriver.FindElement(By.Id("address")).SendKeys("Windale");
            chromeDriver.FindElement(By.Id("city")).SendKeys("Kitchener");
            chromeDriver.FindElement(By.Id("phoneNumber")).SendKeys("122345651");
            chromeDriver.FindElement(By.Id("email")).SendKeys("neha@gmail.com");
            chromeDriver.FindElement(By.Id("make")).SendKeys("testmake9");
            chromeDriver.FindElement(By.Id("model")).SendKeys("testmodel9");
            chromeDriver.FindElement(By.Id("year")).SendKeys("1996");
            chromeDriver.FindElement(By.CssSelector("input[type='submit']")).Click();
            int afterAddCount = (int)chromeDriver.FindElements(By.XPath("//table/tbody/tr"))?.Count;
            // Asset?

            if (afterAddCount > beforAddCount)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        //This test case will be verifying view functionality
        public void Test_ViewSell()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://34.219.12.221:3000/sell/add";

            chromeDriver.FindElement(By.Id("2")).Click();

            string expectResult = "sdfsd";
            string actualResult = chromeDriver.FindElement(By.Id("name")).Text;
            Assert.AreEqual(expectResult, actualResult);
        }

        [Test]
        //This test case will be verifying search functionality
        public void Test_Search()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://34.219.12.221:3000/sell/search";
            chromeDriver.FindElement(By.Id("search_bar")).SendKeys("testmodel2");
            chromeDriver.FindElement(By.Id("btnSearch")).Click();

            int count = (int)chromeDriver.FindElements(By.XPath("//table/tbody/tr"))?.Count;
            if(count > 0)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        //This test case will be verifying email validation message
        public void Test_Add_Email_Format()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://34.219.12.221:3000/sell/add";
            chromeDriver.FindElement(By.Id("email")).SendKeys("neha");
            chromeDriver.FindElement(By.CssSelector("input[type='submit']")).Click();
            string email = chromeDriver.FindElement(By.Id("email")).Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!(match.Success))
            {
                Assert.Pass();
            } else
            {
                Assert.Fail();
            }

        }


        [Test]
        //This testcase will be verifying empty input field for year
        public void Test_Add_Year_Format()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://34.219.12.221:3000/sell/add";
            chromeDriver.FindElement(By.Id("year")).SendKeys(" ");
            chromeDriver.FindElement(By.CssSelector("input[type='submit']")).Click();
            string year = chromeDriver.FindElement(By.Id("year")).Text;
           if(year == "")
            {
                Assert.Pass();
            } else
            {
                Assert.Fail();
            }
        }

        
    }
}
