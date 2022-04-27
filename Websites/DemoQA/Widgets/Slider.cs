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
    internal class Slider
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/slider");

            testSliderDrag();

            driver.Quit();

            if (chain)
            {
                new ProgressBar().start(chain);
            }
        }

        private void testSliderDrag()
        {
            var slider = driver.FindElement(By.XPath("//input[@type='range']"));

            Actions actions = new Actions(driver);

            actions.MoveToElement(slider)
                .ClickAndHold()
                .MoveByOffset(10, 0)
                .MoveByOffset(-20, 0)
                .MoveByOffset(50, 0)
                .MoveByOffset(10, 0)
                .MoveByOffset(-20, 0)
                .Build()
                .Perform();
        }


    }
}
