using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V100.IndexedDB;
using SeleniumBase;
using System;

namespace WAY2Automation.Widgets
{
    internal class AutoComplete : SelActions
    {
        public void start(bool contd)
        {
            open("https://www.way2automation.com/way2auto_jquery/autocomplete.php");

            testDefault();
            testMulVal();
            testCat();
            
            exit();

            if (contd) {
                new DatePicker().start(contd);
            }

        }

        private void testCat()
        {
            FindText("a", "Categories").Click();

            wait1s();

            switchToFrame(2);

            FindID("search").SendKeys("a");

            wait1s();

            FindID("search").SendKeys(Keys.ArrowDown + Keys.Enter);

            wait2s();
        }

        private void testMulVal()
        {
            FindText("a", "Multiple Values").Click();

            wait1s();

            switchToFrame(1);

            wait1s();

            FindID("tags").SendKeys("java");

            wait1s();

            FindID("tags").SendKeys(Keys.ArrowDown + Keys.Enter);

            wait1s();

            FindID("tags").SendKeys("java");

            wait1s();

            FindID("tags").SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            wait2s();

            switchToDefault();
        }

        private void testDefault()
        {
            switchToFrame(0);

            FindID("tags").SendKeys("java");

            wait(500);

            FindID("tags").SendKeys(Keys.ArrowDown + Keys.Enter);

            wait1s();

            switchToDefault();
        }
    }
}
