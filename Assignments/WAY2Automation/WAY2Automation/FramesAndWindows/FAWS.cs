using SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAY2Automation.FramesAndWindows
{
    internal class FAWS : SelActions    
    {
        public void start() {
            open("https://www.way2automation.com/way2auto_jquery/frames-and-windows.php#load_box");

            testDefault();
            testNewWindow();
            testFrameSet();
            testMultWindowns();

            exit();
        }

        private void testMultWindowns()
        {
            FindText("a", "Open Multiple Windows").Click();
            wait1s();
            switchToFrame(3);

            FindText("a", "Open multiple pages").Click();

            wait2s();

            for (int i = 1; i < getDriver().WindowHandles.Count; i++) {
                switchToWindow(i);
                close();
            }

            wait1s();

            switchToWindow(0);
            switchToDefault();
        }

        private void testFrameSet()
        {
            FindText("a", "Frameset").Click();

            wait1s();

            switchToFrame(2);

            FindText("a", "Open Frameset Window").Click();

            switchToWindow(1);

            wait1s();

            close();

            switchToWindow(0);

            switchToDefault();
        }

        private void testNewWindow()
        {
            FindText("a", "Open Seprate New Window").Click();

            switchToFrame(1);

            FindText("a", "Open New Seprate Window").Click();
            wait1s();

            switchToWindow(1);
            wait1s();
            close();

            switchToWindow(0);
            switchToDefault();
        }

        private void testDefault()
        {
            switchToFrame(0);
            FindText("a", "New Browser Tab").Click();
            wait1s();
            switchToWindow(1);
            wait1s();
            close();
            switchToWindow(0);
            wait1s();
            switchToDefault();
        }
    }
}
