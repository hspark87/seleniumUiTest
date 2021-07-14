using System;
using System.Collections;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Threading;
namespace NUnitTestProject1
{
    public class UnitTest2
    {
        public RemoteWebDriver driver = null;

        [SetUp]
        public void setup()
        {

            var capabilities = new ChromeOptions().ToCapabilities();
            var commandTimeout = TimeSpan.FromMinutes(5);
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities, commandTimeout);
            //driver = new RemoteWebDriver(new Uri(" http://localhost:4444/wd/hub"), capabilities.);
            driver.Manage().Window.Maximize();
            
        }

        [TearDown]
        public void teardown()
        {
            driver.Quit();
        }

        [Test]
        //[Parallelizable]
        public void test1()
        {
            Thread thread1 = new Thread(() => test2());
            thread1.Start();

            driver.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(1000);
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("test");
            query.Submit();
            Thread.Sleep(5000);

        }

        [Test]
        //[Parallelizable]
        public void test2()
        {

            driver.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(1000);
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("selenium ");
            query.Submit();
            Thread.Sleep(5000);

        }

    }
}

