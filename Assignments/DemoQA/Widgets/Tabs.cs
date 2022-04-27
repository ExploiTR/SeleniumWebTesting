using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Widgets
{
    internal class Tabs
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/tabs");

            checkSecondTab();
            checkThirdTab();
            checkFirstTab();

            driver.Quit();

            if (chain)
            {
                new ToolTips().start(chain);
            }
        }

        private void checkThirdTab()
        {
            driver.FindElement(By.Id("demo-tab-use")).Click();
            Thread.Sleep(1000);
        }

        private void checkSecondTab()
        {
            driver.FindElement(By.Id("demo-tab-origin")).Click();
            Thread.Sleep(1000);
        }

        private void checkFirstTab()
        {
            driver.FindElement(By.Id("demo-tab-what")).Click();
            Thread.Sleep(1000);
        }
    }
}
