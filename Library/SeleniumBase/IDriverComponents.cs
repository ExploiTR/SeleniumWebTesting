using OpenQA.Selenium;

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

        void navigateBack();

        void navigateForward();

        void exitPrompt();

        IWebElement switchToActive();

        void switchToDefault();

        IAlert switchToAlert();

        IWebDriver switchToFrame(int index);

        void acceptAlert();

        void rejectAlert();

        void sendKeysToAlert(string keys);

        IWebDriver switchToParentFrame();

        void switchToWindow(int index);

        void waitForPageLoad();
    }
}
