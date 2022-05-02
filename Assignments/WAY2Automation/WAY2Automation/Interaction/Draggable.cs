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
using SeleniumBase;

namespace WAY2Automation
{
    internal class Draggable : SelActions
    {
        public void start(bool chain)
        {
            open("https://www.way2automation.com/way2auto_jquery/draggable.php#load_box");

            testDefaultMode();
            switchToContraintPage();
            testConstraints();
            switchToCursorPage();
            testCursors();
            switchToEventPage();
            testEvents();
            switchToDrggableAndSortable();
            testDragAndSort();

            exit();

            if (chain)
            {
                new Droppable().start(chain);
            }
        }

        private void testDragAndSort()
        {
            switchToFrame(4);

            IWebElement drggable = FindXPath("//li[text()='Drag me down']");
            IWebElement sortable = FindXPath("//li[text()='Item 2']");
            IWebElement sortableTo = FindXPath("//li[text()='Item 5']");

            getAction().ClickAndHold(drggable)
                .MoveToElement(sortable).Release().Build().Perform();

            wait(1000);

            getAction().ClickAndHold(sortable)
                .MoveToElement(sortableTo).Release().Build().Perform();
        }

        private void switchToDrggableAndSortable()
        {
            FindXPath("//a[text()='Events']//following::li[1]").Click();
        }

        private void testEvents()
        {
            switchToFrame(3);

            getAction().MoveToElement(FindXPath("//p[contains(text(),'chain of events')]"))
                .ClickAndHold()
                .MoveByOffset(50, 50)
                .Release()
                .ClickAndHold()
                .MoveByOffset(50, 50)
                .Release()
                .ClickAndHold()
                .MoveByOffset(20, -20)
                .MoveByOffset(-20, 20)
                .MoveByOffset(20, -20)
                .MoveByOffset(-20, 20)
                .MoveByOffset(20, -20)
                .MoveByOffset(-20, 20)
                .Release()
                .Build()
                .Perform();

            switchToDefault();
        }

        private void switchToEventPage()
        {
            FindXPath("//a[contains(text(),'Event')]").Click();
            wait(1000);
        }

        private void testCursors()
        {
            switchToFrame(2);

            sqMovementLocal(FindXPath("//p[contains(text(),'stick to the center')]"));
            sqMovementLocal(FindXPath("//p[contains(text(),'-5')]"));
            sqMovementLocal(FindXPath("//p[contains(text(),'bottom')]"));

            switchToDefault();
        }

        private void switchToCursorPage()
        {
            FindXPath("//a[contains(text(),'Cursor')]").Click();
            wait(1000);
        }

        private void switchToContraintPage()
        {
            FindXPath("//a[contains(text(),'Constrain')]").Click();
            wait(1000);
        }

        private void testConstraints()
        {
            switchToFrame(1);

            IWebElement v_cursor = FindXPath("//p[text()='I can be dragged only vertically']");
            IWebElement h_cursor = FindXPath("//p[text()='I can be dragged only horizontally']");

            IWebElement cl_box = FindXPath("//p[contains(text(),'contained within the box')]");
            IWebElement cl_parent = FindXPath("//p[contains(text(),'contained within my parent')]");

            testHorizontalMovement(h_cursor, 0, 150);
            testVerticalMovement(v_cursor, 0, 100);
            sqMovementLocal(cl_box);
            sqMovementLocal(cl_parent);

            switchToDefault();
        }

        private void testDefaultMode()
        {
            switchToFrame(0);

            IWebElement cursor = FindXPath("//div[@id='draggable']");

            sqMovementLocal(cursor);

            switchToDefault();
        }

        private void sqMovementLocal(IWebElement element)
        {
            squareMovement(element, -100, 100, -100, 100);
        }

    }
}
