using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WAY2Automation
{
    internal class Draggable
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.way2automation.com/way2auto_jquery/draggable.php#load_box");
            driver.Manage().Window.Maximize();

            testDefaultMode();
            switchToContraintPage();
            testConstraints();
            switchToCursorPage();
            testCursors();
            switchToEventPage();
            testEvents();

            if (chain)
            {
                new Draggable().start(chain);
            }

            Thread.Sleep(2000);
            driver.Quit();
        }

        private void testEvents()
        {
            driver.SwitchTo().Frame(3);

            IWebElement draggable = driver.FindElement(By.XPath("//p[contains(text(),'chain of events')]"));

            foreach (int i in new int[] { 1, 2 })
            {
                moveSquare(draggable);
            }
        }

        private void switchToEventPage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'Event')]")).Click();
            Thread.Sleep(1000);
        }

        private void testCursors()
        {
            driver.SwitchTo().Frame(2);


            IWebElement center_m = driver.FindElement(By.XPath("//p[contains(text(),'stick to the center')]"));
            IWebElement corner_55 = driver.FindElement(By.XPath("//p[contains(text(),'-5')]"));
            IWebElement bottom = driver.FindElement(By.XPath("//p[contains(text(),'bottom')]"));

            /*  Actions mouseAcc = new Actions(driver);

              mouseAcc.MoveToElement(center_m)
                  .ClickAndHold()
                  .MoveByOffset(300, 0)
                  .MoveByOffset(0, 300)
                  .MoveByOffset(-300, 0)
                  .MoveByOffset(0, -300)
                  .Release()
                  .Build()
                  .Perform();*/

            moveSquare(center_m);
            moveSquare(corner_55);
            moveSquare(bottom);

            driver.SwitchTo().DefaultContent();
        }

        private void switchToCursorPage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'Cursor')]")).Click();
            Thread.Sleep(1000);
        }

        private void switchToContraintPage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'Constrain')]")).Click();
            Thread.Sleep(1000);
        }

        private void testConstraints()
        {
            driver.SwitchTo().Frame(1);

            IWebElement v_cursor = driver.FindElement(By.XPath("//p[text()='I can be dragged only vertically']"));
            IWebElement h_cursor = driver.FindElement(By.XPath("//p[text()='I can be dragged only horizontally']"));

            IWebElement cl_box = driver.FindElement(By.XPath("//p[contains(text(),'contained within the box')]"));
            IWebElement cl_parent = driver.FindElement(By.XPath("//p[contains(text(),'contained within my parent')]"));

            moveSquare(h_cursor);
            moveSquare(v_cursor);
            moveSquare(cl_box);
            moveSquare(cl_parent);

            driver.SwitchTo().DefaultContent();
        }

        private void testDefaultMode()
        {
            driver.SwitchTo().Frame(0);

            IWebElement cursor = driver.FindElement(By.XPath("//div[@id='draggable']"));

            moveSquare(cursor);

            driver.SwitchTo().DefaultContent();
        }

        private void moveSquare(IWebElement cursor)
        {
            Actions actions = new Actions(driver);

            actions.DragAndDropToOffset(cursor, 150, 0)
                .DragAndDropToOffset(cursor, 0, 150)
                .DragAndDropToOffset(cursor, -150, 0)
                .DragAndDropToOffset(cursor, 0, -150)
                .Build().Perform();

        }
    }
}
