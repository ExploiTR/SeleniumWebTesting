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
    internal class Slider : SelActions
    {
        public void start(bool chain)
        {
            open("https://demoqa.com/slider");

            testSliderDrag();

            exit();

            if (chain)
            {
                new ProgressBar().start(chain);
            }
        }

        private void testSliderDrag()
        {
            getAction().MoveToElement(FindXPath("//input[@type='range']"))
                .ClickAndHold()
                .MoveByOffset(10, 0)
                .MoveByOffset(-20, 0)
                .MoveByOffset(50, 0)
                .MoveByOffset(10, 0)
                .MoveByOffset(-20, 0)
                .Build()
                .Perform();
        }


    }
}
