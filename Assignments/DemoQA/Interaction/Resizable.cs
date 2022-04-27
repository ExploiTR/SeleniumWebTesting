using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interaction
{
    internal class Resizable
    {
        private static IWebDriver driver;
        public void start(bool continue_)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/resizable");

            testRestrictedBox();
            testOpenBox();

            driver.Quit();

            if (continue_)
            {
                new Droppable().start(continue_);
            }
        }

        private void testOpenBox()
        {
            var rbR = driver.FindElement(By.XPath("//div[@id='resizable']//span[contains(@class,'react-resizable-handle')]"));
            Actions actions = new Actions(driver);

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,600)");

            actions.MoveToElement(rbR)
                .ClickAndHold()
                .MoveByOffset(200, 200)
                .MoveByOffset(-200, -200)
                .MoveByOffset(100, 200)
                .MoveByOffset(200, 100)
                .Release()
                .Build()
                .Perform();
        }

        private void testRestrictedBox()
        {
            var rbR = driver.FindElement(By.XPath("//div[@id='resizableBoxWithRestriction']//span[contains(@class,'react-resizable-handle')]"));
            Actions actions = new Actions(driver);

            actions.MoveToElement(rbR)
                .ClickAndHold()
                .MoveByOffset(300,300)
                .MoveByOffset(-450, -450)
                .MoveByOffset(100, 200)
                .MoveByOffset(200, 100)
                .Release()
                .Build()
                .Perform();
        }
    }
}
