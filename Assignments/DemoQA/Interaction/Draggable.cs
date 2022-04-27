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
    internal class Draggable
    {
        private static IWebDriver driver;
        public void start(bool continue_)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/dragabble");

            testSimpleDrag();
            testAxisRestrictedDrag();
            testContainerRestrictedDrag();
            testCursorStyles();

            driver.Quit();
        }

        private void testCursorStyles()
        {
            switchToCursorTab();
            checkCenterCursor();
            checkTopLeftCursor();
            checkBottomCursor();
        }

        private void checkBottomCursor()
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(By.Id("cursorBottom")))
                .ClickAndHold()
                .MoveByOffset(200, -200)
                .Release()
                .ContextClick()
                .SendKeys(Keys.Escape)
                .Build()
                .Perform();
        }

        private void checkTopLeftCursor()
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(By.Id("cursorTopLeft")))
                .ClickAndHold()
                .MoveByOffset(200, 0)
                .Release()
                .ContextClick()                
                .SendKeys(Keys.Escape)
                .Build()
                .Perform();
        }

        private void checkCenterCursor()
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(By.Id("cursorCenter")))
                .ClickAndHold()
                .MoveByOffset(200, 200)
                .Release()
                .ContextClick()
                .SendKeys(Keys.Escape)
                .Build()
                .Perform();
        }

        private void switchToCursorTab()
        {
            driver.FindElement(By.Id("draggableExample-tab-cursorStyle")).Click();
            Thread.Sleep(500);
        }

        private void testContainerRestrictedDrag()
        {
            switchToCRTab();
            testContainerDrag();
            testFreeDrag();
        }

        private void testFreeDrag()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.XPath("//span[contains(text(),'contained within my parent')]")))
                .ClickAndHold()
                .MoveByOffset(100, 100)
                .Build()
                .Perform();
        }

        private void testContainerDrag()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.XPath("//div[contains(text(),'contained within the box')]")))
                .ClickAndHold()
                .MoveByOffset(100, 0)
                .MoveByOffset(0, 500)
                .Build()
                .Perform();
        }

        private void switchToCRTab()
        {
            driver.FindElement(By.Id("draggableExample-tab-containerRestriction")).Click();
            Thread.Sleep(500);
        }

        private void testAxisRestrictedDrag()
        {
            switchToRATab();
            testRestrictedX();
            testRestrictedY();
        }

        private void testRestrictedY()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.Id("restrictedY")))
                .ClickAndHold()
                .MoveByOffset(50, 0)
                .MoveByOffset(0, 50).Build().Perform();
        }

        private void testRestrictedX()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.Id("restrictedX")))
                .ClickAndHold()
                .MoveByOffset(50, 0)
                .MoveByOffset(0, 50).Build().Perform();
        }

        private void switchToRATab()
        {
            driver.FindElement(By.Id("draggableExample-tab-axisRestriction")).Click();
            Thread.Sleep(500);
            driver.SwitchTo().ActiveElement();
            Thread.Sleep(500);
        }

        private void testSimpleDrag()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.Id("dragBox")))
                .ClickAndHold()
                .MoveByOffset(100, 100)
                .Build()
                .Perform();
        }
    }
}
