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
using SeleniumBase;


namespace Interaction
{
    internal class Droppable : SelActions
    {
        public void start(bool continue_)
        {
            open("https://demoqa.com/droppable");

            testSimpleDragAndDrop();
            testAcceptRejectDroppable();
            testPropagation();
            testRevertDraggable();

            exit();

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
            new Actions(getDriver()).MoveToElement(FindID("revertable"))
                .ClickAndHold()
                .MoveToElement(FindXPath("//div[@class='revertable-drop-container']//div[@id='droppable']"))
                .Release()
                .Build()
                .Perform();
            wait(1000);
        }

        private void testNonReversibleDraggable()
        {
            new Actions(getDriver()).MoveToElement(FindID("notRevertable"))
                .ClickAndHold()
                .MoveToElement(FindXPath("//div[@class='revertable-drop-container']//div[@id='droppable']"))
                .Release()
                .Build()
                .Perform();
        }

        private void switchToRevertDraggable()
        {
            click(FindID("droppableExample-tab-revertable"));
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
            new Actions(getDriver()).MoveToElement(FindID("dragBox"))
                .ClickAndHold()
                .MoveToElement(FindID("notGreedyInnerDropBox"))
                .Release()
                .Build()
                .Perform();
        }

        private void testGreedyPropagators()
        {
            new Actions(getDriver()).MoveToElement(FindID("dragBox"))
                .ClickAndHold()
                .MoveToElement(FindID("greedyDropBox"))
                .Release()
                .ClickAndHold()
                .MoveToElement(FindID("greedyDropBoxInner"))
                .Release()
                .Build()
                .Perform();
        }

        private void switchToPropagationTab()
        {
            click(FindID("droppableExample-tab-preventPropogation"));
            wait(500);
        }

        private void testAcceptRejectDroppable()
        {
            switchToARD();
            testRejectDroppable();
            testAcceptDroppable();
        }

        private void testRejectDroppable()
        {
            new Actions(getDriver()).MoveToElement(FindXPath("//div[@id='acceptDropContainer']//div[@id='notAcceptable']"))
                .ClickAndHold()
                .MoveToElement(FindXPath("//div[@id='acceptDropContainer']//div[@id='droppable']"))
                .Release()
                .Build()
                .Perform();
        }

        private void testAcceptDroppable()
        {
            new Actions(getDriver()).MoveToElement(FindID("acceptable"))
                .ClickAndHold()
                .MoveToElement(FindXPath("//div[@id='acceptDropContainer']//div[@id='droppable']"))
                .Release()
                .Build()
                .Perform();
        }

        private void switchToARD()
        {
            click(FindID("droppableExample-tab-accept"));
            wait(500);
        }

        private void testSimpleDragAndDrop()
        {
            new Actions(getDriver()).MoveToElement(FindXPath("//div[@id='simpleDropContainer']//div[@id='draggable']"))
                .ClickAndHold()
                .MoveToElement(FindXPath("//div[@id='simpleDropContainer']//div[@id='droppable']"))
                .Release()
                .Build()
                .Perform();
        }
    }
}
