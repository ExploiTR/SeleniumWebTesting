using OpenQA.Selenium;

namespace SeleniumBase
{
    interface IControlFunctions
    {
        void wait(int time);

        void wait_5();

        void wait1s();

        void wait2s();

        void wait3s();

        void wait5s();

        void recordScreen();

        void takeScreenShot();

        void takeScreenShot(IWebElement webElement);

        void stopScreenRecord();

        bool testForValidLink(string link);

        bool testForValidImage(string link);
    }
}
