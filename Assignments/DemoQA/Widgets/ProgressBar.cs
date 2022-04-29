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
    internal class ProgressBar : SelActions
    {
        public void start(bool chain)
        {

            open("https://demoqa.com/progress-bar");

            checkBar();

            exit();

            if (chain)
            {
                new Tabs().start(chain);
            }
        }

        private void checkBar()
        {
            var bar = FindID("startStopButton");
            var readVal = FindXPath("//div[@role='progressbar']");

            bar.Click();

            while (true)
            {
                if (textEquals(readVal,"25%") || textEquals(readVal, "50%") || textEquals(readVal, "75%"))
                {
                    bar.Click();
                    wait(1000);
                    bar.Click();
                    wait(1000);
                }
                else if (readVal.Text.Equals("100%"))
                {
                    wait(1000);
                    break;
                }
            }
            FindID("resetButton").Click();
            wait(1000);
            FindID("startStopButton").Click();
            wait(2500);
        }

    }
}
