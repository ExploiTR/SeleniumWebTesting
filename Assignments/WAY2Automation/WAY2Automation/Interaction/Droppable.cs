using SeleniumBase;
using WAY2Automation.Interaction;

namespace WAY2Automation
{
    internal class Droppable : SelActions
    {
        public void start(bool chain)
        {
            open("https://www.way2automation.com/way2auto_jquery/droppable.php#load_box");

            testDefaultDrop();
            testAcceptDrop();
            testPreventProp();
            testRevertDrop();
            testShoppingDemo(); //bug not loading iteams
            exit();
            if (chain)
            {
                new Resizable().start(chain);
            }
        }

        private void testShoppingDemo()
        {
            FindXPath("//a[text()='Shopping cart demo']").Click();

            wait1s();

            switchToDefault();
        }

        private void testRevertDrop()
        {
            FindXPath("//a[text()='Revert draggable Position']").Click();

            wait1s();

            switchToFrame(3);

            dragAndDropOffset(FindID("draggable"), 0, 50);

            wait(500);

            dragAndDrop(FindID("draggable"), FindID("droppable"));

            wait(500);

            dragAndDropOffset(FindID("draggable"), 0, 50);

            wait(500);

            dragAndDropOffset(FindID("draggable2"), 0, 50);

            wait(500);

            dragAndDrop(FindID("draggable2"), FindID("droppable"));

            wait(500);

            dragAndDropOffset(FindID("draggable2"), 0, 50);

            wait1s();

            switchToDefault();
        }

        private void testPreventProp()
        {
            FindXPath("//a[text()='Prevent propagation']").Click();

            wait1s();

            switchToFrame(2);

            dragAndDrop(FindID("draggable"), FindID("droppable2-inner"));

            wait1s();

            dragAndDrop(FindID("draggable"), FindID("droppable-inner"));

            wait1s();

            switchToDefault();
        }

        private void testAcceptDrop()
        {
            FindXPath("//a[text()='Accept']").Click();

            wait1s();

            switchToFrame(1);

            dragAndDrop(FindID("draggable-nonvalid"), FindID("droppable"));

            wait1s();

            dragAndDrop(FindID("draggable"), FindID("droppable"));

            wait1s();

            switchToDefault();
        }

        private void testDefaultDrop()
        {
            switchToFrame(0);

            dragAndDrop(FindID("draggable"), FindID("droppable"));

            wait(500);

            switchToDefault();
        }
    }
}
