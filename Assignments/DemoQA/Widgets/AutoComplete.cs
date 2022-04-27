using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Widgets
{
    internal class AutoComplete
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/auto-complete");

            testMultiColorName();
            testSingleColorName();

            driver.Quit();

            if (chain)
            {
                new DatePickerInput().start(chain);
            }
        }

        private void testSingleColorName()
        {
            var mu_in = driver.FindElement(By.Id("autoCompleteSingleInput"));

            mu_in.SendKeys("Gree");
            Thread.Sleep(1000);
            mu_in.SendKeys(Keys.Enter);
        }

        private void testMultiColorName()
        {
            var mu_in = driver.FindElement(By.Id("autoCompleteMultipleInput"));

            mu_in.SendKeys("Gree");
            Thread.Sleep(1000);
            mu_in.SendKeys(Keys.Enter);

            mu_in.SendKeys("Bl");
            Thread.Sleep(500);
            mu_in.SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            mu_in.SendKeys(Keys.Enter);
        }
    }
}
