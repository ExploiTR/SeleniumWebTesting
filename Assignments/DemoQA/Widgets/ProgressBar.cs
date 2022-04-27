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
    internal class ProgressBar
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/progress-bar");

            checkBar();

            driver.Quit();

            if (chain)
            {
                new Tabs().start(chain);
            }
        }

        private void checkBar()
        {
            var bar = driver.FindElement(By.Id("startStopButton"));
            var readVal = driver.FindElement(By.XPath("//div[@role='progressbar']"));

            bar.Click();

            while (true)
            {
                if (readVal.Text.Equals("25%") || readVal.Text.Equals("50%") || readVal.Text.Equals("75%"))
                {
                    bar.Click();
                    Thread.Sleep(1000);
                    bar.Click();
                    Thread.Sleep(1000);
                }
                else if (readVal.Text.Equals("100%"))
                {
                    Thread.Sleep(1000);
                    break;
                }
            }
            driver.FindElement(By.Id("resetButton")).Click();
            Thread.Sleep(2500);
        }

    }
}
