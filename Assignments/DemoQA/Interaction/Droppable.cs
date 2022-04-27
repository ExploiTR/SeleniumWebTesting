using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Interaction
{
    internal class Droppable
    {
        private static IWebDriver driver;
        public void start(bool continue_)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/droppable");

            testSimpleDragAndDrop();
            testAcceptRejectDroppable();
            testPropagation();
            testRevertDraggable();

            driver.Quit();

            if (continue_)
            {
                new Draggable().start(continue_);
            }
        }

        private void testRevertDraggable()
        {
            switchToRevertDraggable();
            testReversibleDraggable();
            testNonReversibleDraggable();
        }

        private void testReversibleDraggable()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.Id("revertable")))
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.XPath("//div[@class='revertable-drop-container']//div[@id='droppable']")))
                .Release()
                .Build()
                .Perform();
            Thread.Sleep(1000);
        }

        private void testNonReversibleDraggable()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.Id("notRevertable")))
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.XPath("//div[@class='revertable-drop-container']//div[@id='droppable']")))
                .Release()
                .Build()
                .Perform();
        }

        private void switchToRevertDraggable()
        {
            driver.FindElement(By.Id("droppableExample-tab-revertable")).Click();
            Thread.Sleep(500);
        }

        private void testPropagation()
        {
            switchToPropagationTab();
            testGreedyPropagators();
            testNotGreedyPropagators();
        }

        private void testNotGreedyPropagators()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.Id("dragBox")))
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.Id("notGreedyInnerDropBox")))
                .Release()
                .Build()
                .Perform();
        }

        private void testGreedyPropagators()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.Id("dragBox")))
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.Id("greedyDropBox")))
                .Release()
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.Id("greedyDropBoxInner")))
                .Release()
                .Build()
                .Perform();
        }

        private void switchToPropagationTab()
        {
            driver.FindElement(By.Id("droppableExample-tab-preventPropogation")).Click();
            Thread.Sleep(500);
        }

        private void testAcceptRejectDroppable()
        {
            switchToARD();
            testRejectDroppable();
            testAcceptDroppable();
        }

        private void testRejectDroppable()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.XPath("//div[@id='acceptDropContainer']//div[@id='notAcceptable']")))
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.XPath("//div[@id='acceptDropContainer']//div[@id='droppable']")))
                .Release()
                .Build()
                .Perform();
        }

        private void testAcceptDroppable()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.Id("acceptable")))
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.XPath("//div[@id='acceptDropContainer']//div[@id='droppable']")))
                .Release()
                .Build()
                .Perform();
        }

        private void switchToARD()
        {
            driver.FindElement(By.Id("droppableExample-tab-accept")).Click();
            Thread.Sleep(500);
        }

        private void testSimpleDragAndDrop()
        {
            new Actions(driver).MoveToElement(driver.FindElement(By.XPath("//div[@id='simpleDropContainer']//div[@id='draggable']")))
                .ClickAndHold()
                .MoveToElement(driver.FindElement(By.XPath("//div[@id='simpleDropContainer']//div[@id='droppable']")))
                .Release()
                .Build()
                .Perform();
        }
    }
}
