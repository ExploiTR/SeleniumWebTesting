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
    internal class ToolTips : SelActions
    {
        public void start(bool chain)
        {

            open("https://demoqa.com/tool-tips");

            testHoverOnButton();
            testHoverOnEditText();
            testHoverOnTextItems();

            exit();

            if (chain)
            {
                new Menu().start(chain);
            }
        }

        private void testHoverOnTextItems()
        {
            hoverOnto(FindXPath("//a[text()='Contrary']"));
            wait(1000);
            hoverOnto(FindXPath("//div[@id='texToolTopContainer']//a[2]"));
            wait(1000);
        }

        private void testHoverOnEditText()
        {
            hoverOnto(FindID("toolTipTextField"));
        }

        private void testHoverOnButton()
        {
            hoverOnto(FindID("toolTipButton"));
        }
    }
}
