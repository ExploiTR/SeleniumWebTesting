using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumBase;

namespace WAY2Automation.Interaction
{
    internal class Resizable : SelActions
    {
        public void start(bool contd)
        {

            open("https://www.way2automation.com/way2auto_jquery/resizable.php#load_box");

            testDefaultResize();
            testAnimatedResize();
            testConstraintResize();
            testHelper();
            testMaxMin();

            exit();

            if (contd) {
                new Selectable().start(contd);
            }
        }

        private void testMaxMin()
        {
            FindText("a", "Max/Min size").Click();

            wait1s();

            switchToFrame(4);

            var rbSE = FindXPath("//div[@id='resizable']//div[contains(@class,'ui-resizable-se')]");

            dragAndDropOffset(rbSE, -50, -50);

            wait1s();

            dragAndDropOffset(rbSE, 150, 150);

            wait1s();

            switchToDefault();
        }

        private void testHelper()
        {
            FindText("a", "Helper").Click();

            wait1s();

            switchToFrame(3);

            var rbSE = FindXPath("//div[@id='resizable']//div[contains(@class,'ui-resizable-se')]");

            dragAndDropOffset(rbSE, 150, 150);

            wait1s();

            switchToDefault();

        }

        private void testConstraintResize()
        {
            FindXPath("//a[text()='Constrain resize area']").Click();

            wait1s();

            switchToFrame(2);

            var rbSE = FindXPath("//div[@id='resizable']//div[contains(@class,'ui-resizable-se')]");

            dragAndDropOffset(rbSE, 150, 150);

            wait1s();

            switchToDefault();
        }

        private void testAnimatedResize()
        {
            click(FindXPath("//a[text()='Animate']"));

            wait1s();

            switchToFrame(1);

            var rbSE = FindXPath("//div[@id='resizable']//div[contains(@class,'ui-resizable-se')]");

            dragAndDropOffset(rbSE, 100, 100);

            wait2s();

            switchToDefault();
        }

        private void testDefaultResize()
        {
            switchToFrame(0);

            var rbE = FindXPath("//div[@id='resizable']//div[contains(@class,'ui-resizable-e')]");
            var rbS = FindXPath("//div[@id='resizable']//div[contains(@class,'ui-resizable-s')]");
            var rbSE = FindXPath("//div[@id='resizable']//div[contains(@class,'ui-resizable-se')]");

            dragAndDropOffset(rbE, 100, 0);

            wait1s();

            dragAndDropOffset(rbS, 0, 100);

            wait1s();

            dragAndDropOffset(rbSE, 100, 100);

            wait1s();

            switchToDefault();
        }
    }
}
