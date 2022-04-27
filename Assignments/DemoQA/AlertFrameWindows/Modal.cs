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
    internal class Modal
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/modal-dialogs");

            interactWithSmallModal();
            interactWithLargeModal();

            driver.Quit();
        }

        private void interactWithLargeModal()
        {
            driver.FindElement(By.Id("showLargeModal")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().ActiveElement();
            driver.FindElement(By.Id("closeLargeModal")).Click();
            driver.SwitchTo().DefaultContent();
        }

        private void interactWithSmallModal()
        {
            driver.FindElement(By.Id("showSmallModal")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().ActiveElement();
            driver.FindElement(By.Id("closeSmallModal")).Click();
            driver.SwitchTo().DefaultContent();
        }
    }
}
