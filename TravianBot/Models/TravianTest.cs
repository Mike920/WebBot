using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Web;

namespace TravianBot.Models
{
    //[TestFixture]
    public class Travian
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;


        public void RunTest()
        {
            SetupTest();
            TheTravianTest();
            TeardownTest();
        }

        //[SetUp]
        public void SetupTest()
        {
            var ieServerPath = HttpContext.Current.Server.MapPath("~/");
            driver = new InternetExplorerDriver(ieServerPath, new InternetExplorerOptions { IntroduceInstabilityByIgnoringProtectedModeSettings = true});
            baseURL = "http://tx3.travian.pl/";
            verificationErrors = new StringBuilder();
        }

        //[TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
           // Assert.AreEqual("", verificationErrors.ToString());
        }

        //[Test]
        public void TheTravianTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Name("name")).Clear();
            driver.FindElement(By.Name("name")).SendKeys("boruke");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("kamilkos");
            driver.FindElement(By.Id("s1")).Click();
            Thread.Sleep(new TimeSpan(0, 0, 2));
            driver.FindElement(By.PartialLinkText("GRABIEŻ")).Click();
            driver.FindElement(By.PartialLinkText("GRABIEŻ")).Click();
            Thread.Sleep(new TimeSpan(0, 0, 2));
            
            //driver.FindElement(By.XPath("//a[contains(text(),'" + "GRABIEŻ" + "')]")).Click();
            driver.FindElement(By.CssSelector("#raidList > div:nth-child(1) > form > div.listContent > div.detail > div.markAll > input")).Click();
            Thread.Sleep(new TimeSpan(0, 0, 2));
           // driver.FindElement(By.CssSelector("#raidList > div:nth-child(1) > form > div.listContent > div.detail > div.markAll > input")).Click();

            driver.FindElement(By.CssSelector("#raidList > div:nth-child(1) > form > div.listContent > button")).Click();
            Thread.Sleep(new TimeSpan(0, 0, 2));
           // driver.FindElement(By.CssSelector("#raidList > div:nth-child(1) > form > div.listContent > button")).Click();


            //old
            //driver.Navigate().GoToUrl(baseURL + "/");
            //driver.FindElement(By.Name("name")).Clear();
            //driver.FindElement(By.Name("name")).SendKeys("boruke");
            //driver.FindElement(By.Name("password")).Clear();
            //driver.FindElement(By.Name("password")).SendKeys("kamilkos");
            //driver.FindElement(By.Id("s1")).Click();
            //driver.FindElement(By.LinkText("GRABIEŻ")).Click();
            //driver.FindElement(By.XPath("//div/input")).Click();
            //driver.FindElement(By.XPath("//form/div[2]/button")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}