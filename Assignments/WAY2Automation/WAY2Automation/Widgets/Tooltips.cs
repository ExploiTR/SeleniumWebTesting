using SeleniumBase;
using System;

namespace WAY2Automation.Widgets
{
    internal class Tooltips : SelActions
    {
        public void start()
        {

            open("https://www.way2automation.com/way2auto_jquery/tooltip.php#load_box");

            testDefault();

            exit();
        }

        private void testDefault()
        {
            switchToFrame(0);
            hoverOnto(FindText("a", "Tooltips"));
            wait2s();
            hoverOnto(FindText("a", "ThemeRoller"));
            wait2s();
            hoverOnto(FindID("age"));
            wait2s();
            switchToDefault();
        }
    }
}
