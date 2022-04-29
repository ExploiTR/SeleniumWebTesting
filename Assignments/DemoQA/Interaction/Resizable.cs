using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumBase;

namespace Interaction
{
    internal class Resizable : SelActions
    {
        public void start(bool continue_)
        {
            open("https://demoqa.com/resizable");

            testRestrictedBox();
            testOpenBox();

            exit();

            if (continue_)
            {
                new Droppable().start(continue_);
            }
        }

        private void testOpenBox()
        {
            var rbR = FindXPath("//div[@id='resizable']//span[contains(@class,'react-resizable-handle')]");

            scrollPage(0, 600);

            getAction().MoveToElement(rbR)
                .ClickAndHold()
                .MoveByOffset(200, 200)
                .MoveByOffset(-200, -200)
                .MoveByOffset(100, 200)
                .MoveByOffset(200, 100)
                .Release()
                .Build()
                .Perform();
        }

        private void testRestrictedBox()
        {
            var rbR = FindXPath("//div[@id='resizableBoxWithRestriction']//span[contains(@class,'react-resizable-handle')]");

            getAction().MoveToElement(rbR)
                .ClickAndHold()
                .MoveByOffset(300, 300)
                .MoveByOffset(-450, -450)
                .MoveByOffset(100, 200)
                .MoveByOffset(200, 100)
                .Release()
                .Build()
                .Perform();
        }
    }
}
