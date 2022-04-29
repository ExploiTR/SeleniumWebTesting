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
    internal class Menu : SelActions
    {
        public void start(bool chain)
        {
            open("https://demoqa.com/menu");

            moveToMainItem();
            moveToSubItem();
            moveToSub_SubItem();

            exit();

            if (chain)
            {
                new SelectMenu().start();
            }
        }

        private void moveToSub_SubItem()
        {
            hoverOnto(FindXPath("//a[text()='Sub Sub Item 2']"));
        }

        private void moveToSubItem()
        {
            hoverOnto(FindXPath("//a[text()='SUB SUB LIST »']"));
        }

        private void moveToMainItem()
        {
            hoverOnto(FindXPath("//a[text()='Main Item 2']"));
        }
    }
}
