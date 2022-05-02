using OpenQA.Selenium;
using SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAY2Automation.Widgets
{
    internal class DatePicker : SelActions
    {
        public void start(bool contd)
        {
            open("https://www.way2automation.com/way2auto_jquery/datepicker.php#load_box");

            testDefault();
            testAnime();
            testMonthYear();
            testFormatDate();

            exit();

            if (contd) {
                new Menu().start(contd);
            }

        }

        private void testFormatDate()
        {
            FindText("a", "Format date").Click();

            wait1s();

            switchToFrame(3);

            clickAndThenSendKeys(FindID("format"), Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            wait1s();

            FindID("datepicker").Click();

            FindText("a", "13").Click();

            wait2s();

            switchToDefault();
        }

        private void testMonthYear()
        {
            FindText("a", "Display month & year").Click();

            wait1s();

            switchToFrame(2);

            FindID("datepicker").Click();

            wait_5();

            switchToActive();

            FindXPath("//select[@data-handler='selectMonth']").Click();

            FindXPath("//select[@data-handler='selectMonth']").SendKeys(Keys.ArrowDown + Keys.Enter);

            wait1s();

            FindXPath("//select[@data-handler='selectYear']").Click();

            FindXPath("//select[@data-handler='selectYear']").SendKeys(Keys.ArrowDown + Keys.Enter);

            wait1s();

            FindText("a", "13").Click();

            wait1s();

            switchToDefault();
        }

        private void testAnime()
        {
            FindText("a", "Animations").Click();

            wait1s();

            switchToFrame(1);

            FindID("datepicker").Click();

            wait1s();

            switchAnimeMode();

            wait1s();

            FindID("datepicker").Click();

            wait1s();

            switchAnimeMode();

            wait1s();

            FindID("datepicker").Click();

            wait1s();

            switchToDefault();
        }

        void switchAnimeMode()
        {
            FindText("a", "13").Click();
            wait(500);
            FindID("anim").Click();
            FindID("anim").SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }

        private void testDefault()
        {
            switchToFrame(0);

            FindID("datepicker").Click();

            wait1s();

            switchToActive();

            FindText("span", "Next").Click();

            wait1s();

            FindText("span", "Next").Click();

            wait1s();

            FindText("span", "Prev").Click();

            wait1s();

            FindText("a", "13").Click();

            wait1s();

            switchToDefault();
        }
    }
}
