using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Widgets
{
    internal class Accordian
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/accordian");

            openCloseFirst();
            openCloseSecond();
            openCloseThird();

            driver.Quit();

            if (chain)
            {
                new AutoComplete().start(chain);
            }
        }

        private void openCloseThird()
        {
            oac("section3Heading");
        }

        private void openCloseSecond()
        {
            oac("section2Heading");
        }

        private void openCloseFirst()
        {
            oac("section1Heading");
        }

        private void oac(string id)
        {
            driver.FindElement(By.Id(id)).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id(id)).Click();
        }
    }
}
