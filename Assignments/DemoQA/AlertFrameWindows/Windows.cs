using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlertFrameWindows
{
    internal class Windows
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");

            testNewTab();
            testNewWindow();
            testWindowMessage();

            driver.Quit();

            if (chain) {
                new Alerts().start(chain);
            }

        }

        private void testWindowMessage()
        {
            testHandleInternal("messageWindowButton");
        }

        private void testNewWindow()
        {
            testHandleInternal("windowButton");
        }

        private void testNewTab()
        {
            testHandleInternal("tabButton");
        }

        private void testHandleInternal(string id)
        {
            driver.FindElement(By.Id(id)).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }
    }
}
