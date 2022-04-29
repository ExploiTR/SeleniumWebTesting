using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBase;


namespace AlertFrameWindows
{
    internal class Alerts : SelActions
    {
        public void start(bool chain)
        {
            open("https://demoqa.com/alerts");

            testSimpleAlert();
            testTimerAlert();
            testConfirmAlert();
            testInputPromptAlert();

            exit();

            if (chain)
            {
                new Frames().start(chain);
            }

        }

        private void testInputPromptAlert()
        {
            FindID("promtButton").Click();
            wait(1000);
            sendKeysToAlert("YOOOOOOOOOOOOOOO");
            wait(1000);
            acceptAlert();
            wait(2000);
        }

        private void testConfirmAlert()
        {
            FindID("confirmButton").Click();
            wait(1000);
            acceptAlert();
            wait(1000);
            FindID("confirmButton").Click();
            wait(1000);
            rejectAlert();
        }

        private void testTimerAlert()
        {
            FindID("timerAlertButton").Click();
            wait(5500);
            acceptAlert();
            wait(1000);
        }

        private void testSimpleAlert()
        {
            FindID("alertButton").Click();
            wait(1000);
            acceptAlert();
        }
    }
}
