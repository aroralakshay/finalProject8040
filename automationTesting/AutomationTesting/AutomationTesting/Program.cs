using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTesting
{
    public class Program
    {
        static void Main(string[] args)
        {
            //IWebDriver firefoxDriver = new FirefoxDriver();
           // newCustomerTest();
           // viewTest();
            SearhcTest();


        }

        public static void newCustomerTest()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://34.219.12.221:3000/";

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

            Console.WriteLine("ckjd");
        }

        public static void viewTest()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://34.219.12.221:3000/sell/add";
            
            chromeDriver.FindElement(By.Id("2")).Click();

            string expectResult = "";
            string actualResult = chromeDriver.FindElement(By.Id("name")).Text;
            Console.WriteLine();
        }

        public static void SearhcTest()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://34.219.12.221:3000/sell/search";
            chromeDriver.FindElement(By.Id("search_bar")).SendKeys("testmodel2");
            chromeDriver.FindElement(By.Id("btnSearch")).Click();

            int count = (int)chromeDriver.FindElements(By.XPath("//table/tbody/tr"))?.Count;
            Console.WriteLine();
        }
    }
}
