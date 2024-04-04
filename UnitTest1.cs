using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace If_insurance_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            IWebDriver driver = new ChromeDriver(options);
            try
            {
                driver.Navigate().GoToUrl("https://www.if.lv/privatpersonam");
                driver.FindElement(By.Id("onetrust-reject-all-handler")).Click();
                driver.FindElement(By.CssSelector("[href = '/par-if']")).Click();
                driver.FindElement(By.XPath("//a[@href='/par-if/darbs-if' and contains(@class, 'desktop-menu-action')]")).Click();
                driver.FindElement(By.CssSelector("[href='/par-if/darbs-if/vakances']")).Click();
                driver.FindElement(By.XPath("//*[@id=\'90f8aefa847d4019b761950eb2ba9a88\']")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(3));
                driver.FindElement(By.XPath("//*[text()='Quality Assurance Specialit']"));
            }
            catch (Exception ex)
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                //File path needs to be changed for each env
                string filePath = "C:\\Users\\march\\Desktop\\screenshot.png";
                screenshot.SaveAsFile(filePath);
                throw;
            }
        }
    }
}
