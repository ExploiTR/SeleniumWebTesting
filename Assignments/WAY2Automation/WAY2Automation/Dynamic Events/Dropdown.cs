using OpenQA.Selenium;
using SeleniumBase;

namespace WAY2Automation.Dynamic_Events
{
    internal class Dropdown : SelActions
    {
        public void start()
        {
            open("https://www.way2automation.com/way2auto_jquery/dropdown.php#load_box");

            testSelect();
            testSelectLegacy();

            exit();
        }

        private void testSelectLegacy()
        {
            FindText("a", "Enter Country").Click();

            wait2s();

            switchToFrame(1);

            FindXPath("//option[@value='India']//ancestor::select").Click();

            scrollForElementVisibility(FindXPath("//select//option[@value='India']"));

            FindXPath("//select//option[@value='India']").Click();

            wait1s();
        }

        private void testSelect()
        {
            switchToFrame(0);

            FindXPath("//option[@value='India']//ancestor::select").Click();

            scrollForElementVisibility(FindXPath("//select//option[@value='India']"));

            FindXPath("//select//option[@value='India']").Click();

            switchToDefault();
        }
    }
}
