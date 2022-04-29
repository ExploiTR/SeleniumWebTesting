using OpenQA.Selenium;
using SeleniumBase;


namespace Interaction
{
    internal class Draggable : SelActions
    {
        public void start(bool continue_)
        {
            open("https://demoqa.com/dragabble");

            testSimpleDrag();
            testAxisRestrictedDrag();
            testContainerRestrictedDrag();
            testCursorStyles();

            exit();
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
            getAction()
                .MoveToElement(FindID("cursorBottom"))
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
            getAction()
                .MoveToElement(FindID("cursorTopLeft"))
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
            getAction()
                .MoveToElement(FindID("cursorCenter"))
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
            FindID("draggableExample-tab-cursorStyle").Click();
            wait(500);
        }

        private void testContainerRestrictedDrag()
        {
            switchToCRTab();
            testContainerDrag();
            testFreeDrag();
        }

        private void testFreeDrag()
        {
            getAction().MoveToElement(FindXPath("//span[contains(text(),'contained within my parent')]"))
                .ClickAndHold()
                .MoveByOffset(100, 100)
                .Build()
                .Perform();
        }

        private void testContainerDrag()
        {
            getAction().MoveToElement(FindXPath("//div[contains(text(),'contained within the box')]"))
                .ClickAndHold()
                .MoveByOffset(100, 0)
                .MoveByOffset(0, 500)
                .Build()
                .Perform();
        }

        private void switchToCRTab()
        {
            FindID("draggableExample-tab-containerRestriction").Click();
            wait(500);
        }

        private void testAxisRestrictedDrag()
        {
            switchToRATab();
            testRestrictedX();
            testRestrictedY();
        }

        private void testRestrictedY()
        {
         /*   getAction().MoveToElement(FindID("restrictedY"))
                .ClickAndHold()
                .MoveByOffset(50, 0)
                .MoveByOffset(0, 50).Build().Perform();*/
            testVerticalMovement(FindID("restrictedY"), -50, 50);
        }

        private void testRestrictedX()
        {
          /*  getAction().MoveToElement(FindID("restrictedX"))
                .ClickAndHold()
                .MoveByOffset(50, 0)
                .MoveByOffset(0, 50).Build().Perform();*/
            testHorizontalMovement(FindID("restrictedX"), -50, 50);
        }

        private void switchToRATab()
        {
            FindID("draggableExample-tab-axisRestriction").Click();
            wait(500);
            switchToActive();
            wait(500);
        }

        private void testSimpleDrag()
        {
            getAction().MoveToElement(FindID("dragBox"))
                .ClickAndHold()
                .MoveByOffset(100, 100)
                .Build()
                .Perform();
        }
    }
}
