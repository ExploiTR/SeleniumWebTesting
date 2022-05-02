using OpenQA.Selenium;
using SeleniumBase;

namespace WAY2Automation.Alerts
{
    internal class Alarts : SelActions
    {
        public void start()
        {
            open("https://www.way2automation.com/way2auto_jquery/alert.php#load_box");

            testSimple();
            testInput();

            exit();
        }

        private void testInput()
        {
            FindTextTagless("Input Alert").Click();

            switchToFrame(1);

            FindTextTagless("Click the button to demonstrate the Input box.").Click();

            wait1s();

            IAlert al = switchToAlert();
            al.SendKeys("HAHAHHA");
            al.Accept();

            wait1s();

            switchToDefault();
        }

        private void testSimple()
        {
            switchToFrame(0);

            FindTextTagless("Click the button to display an alert box:").Click();

            wait1s();

            switchToAlert().Accept();

            switchToDefault();
        }
    }
}
