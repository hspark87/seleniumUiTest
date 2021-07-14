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

namespace NUnitTestProject1
{
    public class Browser_ops
    {
        IWebDriver webDriver;
        public void Init_Browser()
        {
            /*    
             //server
            webDriver = new ChromeDriver(@"C:\Program Files\Google\Chrome\Application\");
            //webDriver = new FirefoxDriver(@"C:\Program Files\Mozilla Firefox");
            webDriver.Manage().Window.Maximize();
            */
            
            //grid 
            var uri = "http://localhost:4444/wd/hub";
            //var uri = "http://10.1.55.46:4444/wd/hub";
            //var uri = "http://10.1.55.46:4444/wd/hub";
            var capabilities =  new ChromeOptions().ToCapabilities();
            var commandTimeout = TimeSpan.FromMinutes(5);
            webDriver = new RemoteWebDriver(new Uri(uri), capabilities);
            webDriver.Manage().Window.Maximize();
        
        }

        public string Title
        {
            get { return webDriver.Title; }
        }

        public void Goto(string url)
        {
            //webDriver.Url = url;
            webDriver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            webDriver.Quit();
        }

        public IWebDriver getDriver
        {
            get { return webDriver; }
        }
    }
    class NUnit_Demo_1
    {
        Browser_ops brow = new Browser_ops();
        //string test_url = "http://10.1.55.201/Auth/Login";
        string test_url = "http://localhost:8080";
        IWebDriver driver;
        [SetUp]
        public void start_Browser()
        {
            brow.Init_Browser();

        }

        [Test]
        public void test_Browserops()
        {
            brow.Goto(test_url);
            //System.Threading.Thread.Sleep(2000);
            
            driver = brow.getDriver;

            /*
             //자바스크립트 Test
            var tsetList = new ArrayList();
            tsetList.Add("20019");
            tsetList.Add("박혁수");
            tsetList.Add("☆☆☆☆☆☆☆");
            tsetList.Add("朴赫");
            tsetList.Add("じっせき");
            tsetList.Add("مُشَارَفَة");

            int test = driver.FindElements(By.Name("tag")).Count;
            for(int j = 0; j < tsetList.Count; j++){
                for (int i = 0; i < test; i++)
                {
                    driver.FindElement(By.Id("tag_"+i)).SendKeys(tsetList[j].ToString());
                }
                if (j == 5)
                {
                    break;
                }
                driver.FindElement(By.Id("tag_0")).Clear();
                driver.FindElement(By.Id("tag_1")).Clear();
                driver.FindElement(By.Id("tag_2")).Clear();
                driver.FindElement(By.Id("tag_3")).Clear();
                driver.FindElement(By.Id("tag_4")).Clear();
            }
            driver.FindElement(By.Id("testButton")).Click();
            */
            /*
             // Test
            driver.FindElement(By.Id("LOGIN_ID")).Click();
            driver.FindElement(By.Id("LOGIN_ID")).SendKeys("20019");
            driver.FindElement(By.Id("USER_PWD")).SendKeys("zoflrja.");
            driver.FindElement(By.Id("USER_PWD")).SendKeys(Keys.Enter);
            driver.FindElement(By.CssSelector(".hidden-xs:nth-child(1).hidden-xs")).Click();
            driver.FindElement(By.CssSelector(".hidden-xs:nth-child(2).hidden-xs")).Click();
            driver.FindElement(By.CssSelector(".hidden-xs:nth-child(3).hidden-xs")).Click();
            driver.FindElement(By.CssSelector(".hidden-xs:nth-child(4).hidden-xs")).Click();
            driver.FindElement(By.CssSelector(".hidden-xs:nth-child(5).hidden-xs")).Click();
            driver.FindElement(By.LinkText("근태관리")).Click();
            driver.FindElement(By.LinkText("커뮤니티")).Click();
            driver.FindElement(By.LinkText("작업지시관리")).Click();
            driver.FindElement(By.CssSelector(".hidden-xs:nth-child(1) .hidden-xs")).Click();
            driver.FindElement(By.LinkText("일정현황")).Click();
            driver.FindElement(By.CssSelector("#JsTreeNodeId26 > a")).Click();
            driver.FindElement(By.LinkText("월간일정")).Click();
            driver.FindElement(By.LinkText("주간일정")).Click();
            driver.FindElement(By.LinkText("업무지시")).Click();
            driver.FindElement(By.LinkText("업무보고설정")).Click();
            driver.FindElement(By.LinkText("업무보고작성")).Click();
            driver.FindElement(By.LinkText("업무보고승인")).Click();
            driver.FindElement(By.LinkText("업무보고현황")).Click();
            driver.FindElement(By.LinkText("시설등록")).Click();
            driver.FindElement(By.LinkText("시설현황")).Click();
            driver.FindElement(By.LinkText("사용승인")).Click();
            driver.FindElement(By.LinkText("예약현황")).Click();
            driver.FindElement(By.LinkText("업무결재")).Click();
            driver.FindElement(By.LinkText("업무보고작성")).Click();
            driver.FindElement(By.LinkText("업무보고 승인")).Click();
            driver.FindElement(By.LinkText("업무보고현황")).Click();
            driver.FindElement(By.LinkText("내 승인설정")).Click();
            driver.FindElement(By.LinkText("내 보고설정")).Click();
            driver.FindElement(By.CssSelector(".hidden-xs:nth-child(3) .hidden-xs")).Click();
            driver.FindElement(By.CssSelector(".hidden-xs:nth-child(4) .fa")).Click();
            driver.FindElement(By.LinkText("고객현황")).Click();
            driver.FindElement(By.CssSelector("#JsTreeNodeId40 > a")).Click();
            driver.FindElement(By.LinkText("고객 Contact관리")).Click();
            driver.FindElement(By.LinkText("고객 Feedback관리")).Click();
            driver.FindElement(By.CssSelector(".hidden-xs:nth-child(5) .hidden-xs")).Click();
            driver.FindElement(By.CssSelector("#JsTreeNodeId17 > a")).Click();
            driver.FindElement(By.CssSelector("#JsTreeNodeId18 > a")).Click();
            driver.FindElement(By.CssSelector("#JsTreeNodeId23 > a")).Click();
            driver.FindElement(By.LinkText("좋은 글")).Click();
            driver.FindElement(By.LinkText("도서구입신청")).Click();
            driver.FindElement(By.LinkText("읽고나눔")).Click();
            driver.FindElement(By.LinkText("근태관리")).Click();
            driver.FindElement(By.LinkText("근태신청")).Click();
            driver.FindElement(By.LinkText("근태현황")).Click();
            driver.FindElement(By.LinkText("출결현황")).Click();
            driver.FindElement(By.LinkText("휴가현황")).Click();
            driver.FindElement(By.LinkText("휴가계획")).Click();
            driver.FindElement(By.LinkText("커뮤니티")).Click();
            driver.FindElement(By.LinkText("회사공지")).Click();
            driver.FindElement(By.LinkText("장애 및 개선요청")).Click();
            driver.FindElement(By.LinkText("제안제도")).Click();
            driver.FindElement(By.LinkText("지원사업-공고")).Click();
            driver.FindElement(By.LinkText("사업계획")).Click();
            driver.FindElement(By.LinkText("프로젝트(수행)")).Click();
            driver.FindElement(By.LinkText("프로젝트(계획)")).Click();
            driver.FindElement(By.LinkText("(주)디엘정보기술")).Click();
            driver.FindElement(By.CssSelector("#JsTreeNodeId9 > a")).Click();
            driver.FindElement(By.LinkText("개발자 게시판")).Click();
            driver.FindElement(By.LinkText("회사표준")).Click();
            driver.FindElement(By.LinkText("식수 현황")).Click();
            driver.FindElement(By.LinkText("작업지시관리")).Click();
            driver.FindElement(By.LinkText("작업지시 등록")).Click();
            driver.FindElement(By.LinkText("내 작업 등록")).Click();
            driver.FindElement(By.LinkText("작업현황")).Click();
            */
            System.Threading.Thread.Sleep(3000);
        }

        [TearDown]
        public void close_Browser()
        {
            brow.Close();
        }
    }
}

