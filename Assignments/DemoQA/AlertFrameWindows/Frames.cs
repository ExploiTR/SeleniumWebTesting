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
    internal class Frames : SelActions
    {
        public void start(bool chain)
        {
            open("https://demoqa.com/frames");

            exit();

            if (chain)
            {
                new NestedFrames().start(chain);
            }
        }
    }
}
