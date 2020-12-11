
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AutomationTest
{
    [TestFixture]
    public class WebsiteTests
    {
        [Test]

        //This test case will be verifying add functionality
        public void Test_Add_Sell()
        {
            IWebDriver firefoxDriver = new FirefoxDriver();
            firefoxDriver.Url = "http://35.161.142.191:3000/sell";

            firefoxDriver.FindElement(By.LinkText("New Customer")).Click();
            int beforAddCount = (int)firefoxDriver.FindElements(By.XPath("//table/tbody/tr"))?.Count;
            firefoxDriver.FindElement(By.Id("name")).SendKeys("car1");
            firefoxDriver.FindElement(By.Id("address")).SendKeys("Windale");
            firefoxDriver.FindElement(By.Id("city")).SendKeys("Kitchener");
            firefoxDriver.FindElement(By.Id("phoneNumber")).SendKeys("122345651");
            firefoxDriver.FindElement(By.Id("email")).SendKeys("neha@gmail.com");
            firefoxDriver.FindElement(By.Id("make")).SendKeys("testmake9");
            firefoxDriver.FindElement(By.Id("model")).SendKeys("testmodel9");
            firefoxDriver.FindElement(By.Id("year")).SendKeys("1996");
            firefoxDriver.FindElement(By.CssSelector("input[type='submit']")).Click();
            int afterAddCount = (int)firefoxDriver.FindElements(By.XPath("//table/tbody/tr"))?.Count;
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
            IWebDriver firefoxDriver = new FirefoxDriver();
            firefoxDriver.Url = "http://35.161.142.191:3000/sell/add";

            firefoxDriver.FindElement(By.Id("2")).Click();

            string expectResult = "sdfsd";
            string actualResult = firefoxDriver.FindElement(By.Id("name")).Text;
            Assert.AreEqual(expectResult, actualResult);
        }

        [Test]
        //This test case will be verifying search functionality
        public void Test_Search()
        {
            IWebDriver firefoxDriver = new FirefoxDriver();
            firefoxDriver.Url = "http://35.161.142.191:3000/sell/search";
            firefoxDriver.FindElement(By.Id("search_bar")).SendKeys("testmodel2");
            firefoxDriver.FindElement(By.Id("btnSearch")).Click();

            int count = (int)firefoxDriver.FindElements(By.XPath("//table/tbody/tr"))?.Count;
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
            IWebDriver firefoxDriver = new FirefoxDriver();
            firefoxDriver.Url = "http://35.161.142.191:3000/sell/add";
            firefoxDriver.FindElement(By.Id("email")).SendKeys("neha");
            firefoxDriver.FindElement(By.CssSelector("input[type='submit']")).Click();
            string email = firefoxDriver.FindElement(By.Id("email")).Text;
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
            IWebDriver firefoxDriver = new FirefoxDriver();
            firefoxDriver.Url = "http://35.161.142.191:3000/sell/add";
            firefoxDriver.FindElement(By.Id("year")).SendKeys(" ");
            firefoxDriver.FindElement(By.CssSelector("input[type='submit']")).Click();
            string year = firefoxDriver.FindElement(By.Id("year")).Text;
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
