using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBase
{
    interface IDriverComponents
    {
        void open(string link);

        void open(string link, DriverConfig config);

        void openWindow(string link);

        void refresh();

        void switchBackToPreviousDriver();

        void close();

        void exit();

        void execScript(string script, params object[] args);

        void scrollPage(int hz, int ver);

        void scrollForElementVisibility(IWebElement element);

        IWebElement switchToActive();

        void switchToDefault();

        IAlert switchToAlert();

        IWebDriver switchToFrame(int index);

        void acceptAlert();

        void rejectAlert();

        void sendKeysToAlert(string keys);

        IWebDriver switchToParentFrame();

        void switchToWindow(int index);
    }
}
