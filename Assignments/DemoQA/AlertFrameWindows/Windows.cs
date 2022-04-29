using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumBase;

namespace AlertFrameWindows
{
    internal class Windows : SelActions
    {
        public void start(bool chain)
        {

            open("https://demoqa.com/browser-windows");

            testNewTab();
            testNewWindow();
            testWindowMessage();

            exit();

            if (chain) {
                new Alerts().start(chain);
            }

        }

        private void testWindowMessage()
        {
            testHandleInternal("messageWindowButton");
        }

        private void testNewWindow()
        {
            testHandleInternal("windowButton");
        }

        private void testNewTab()
        {
            testHandleInternal("tabButton");
        }

        private void testHandleInternal(string id)
        {
            FindID(id).Click();
            wait(1000);
            switchToWindow(1);
            close();
            switchToWindow(0);
        }
    }
}
