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
    internal class Frames
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/frames");

            driver.Quit();

            if (chain)
            {
                new NestedFrames().start(chain);
            }
        }
    }
}
