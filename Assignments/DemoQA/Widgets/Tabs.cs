using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumBase;  

namespace Widgets
{
    internal class Tabs : SelActions
    {
        public void start(bool chain)
        {

            open("https://demoqa.com/tabs");

            checkSecondTab();
            checkThirdTab();
            checkFirstTab();

            exit();

            if (chain)
            {
                new ToolTips().start(chain);
            }
        }

        private void checkThirdTab()
        {
            FindID("demo-tab-use").Click();
            wait(1000);
        }

        private void checkSecondTab()
        {
            FindID("demo-tab-origin").Click();
            wait(1000);
        }

        private void checkFirstTab()
        {
            FindID("demo-tab-what").Click();
            wait(1000);
        }
    }
}
