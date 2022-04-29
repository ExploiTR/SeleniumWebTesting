using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBase
{
    interface IControlFunctions
    {
        void wait(int time);

        void recordScreen();

        void takeScreenShot();

        void takeScreenShot(IWebElement webElement);

        void stopScreenRecord();

        bool testForValidLink(string link);

        bool testForValidImage(string link);
    }
}
