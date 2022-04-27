using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AlertFrameWindows
{
    internal class Alerts
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/alerts");

            testSimpleAlert();
            testTimerAlert();
            testConfirmAlert();
            testInputPromptAlert();

            driver.Quit();

            if (chain)
            {
                new Frames().start(chain);
            }

        }

        private void testInputPromptAlert()
        {
            driver.FindElement(By.Id("promtButton")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().SendKeys("YOOOOOOOOOOOOOOO");
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
        }

        private void testConfirmAlert()
        {
            driver.FindElement(By.Id("confirmButton")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("confirmButton")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Dismiss();
        }

        private void testTimerAlert()
        {
            driver.FindElement(By.Id("timerAlertButton")).Click();
            Thread.Sleep(5500);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
        }

        private void testSimpleAlert()
        {
            driver.FindElement(By.Id("alertButton")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }
    }
}
