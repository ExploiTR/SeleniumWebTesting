using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumBase;

namespace WAY2Automation.Widgets
{
    internal class Accordion : SelActions
    {
        public void start(bool contd) {

            open("https://www.way2automation.com/way2auto_jquery/accordion.php#load_box");

            testDefault();
            testIcons();
            testSpacing();

            exit();

            if (contd) {
                new AutoComplete().start(contd);
            }
        }

        private void testSpacing()
        {
            FindText("a", "Fill Space").Click();

            wait1s();

            switchToFrame(2);

            dragAndDropOffset(FindXPath("//div[contains(@class,'ui-resizable-se')]"), 150, 150);

            wait1s();
            
            switchToDefault();
        }

        private void testIcons()
        {
            FindText("a", "Customize icons").Click();

            wait1s();

            switchToFrame(1);

            FindText("h3", "Section 2").Click();

            wait1s();

            FindText("span", "Toggle icons").Click();

            wait1s();

            switchToDefault();
        }

        private void testDefault()
        {
            switchToFrame(0);

            FindText("h3", "Section 2").Click();

            wait1s();

            switchToDefault();
        }
    }
}
