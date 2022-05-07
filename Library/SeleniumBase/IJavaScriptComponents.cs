using OpenQA.Selenium;

namespace SeleniumBase
{
    interface IJavaScriptComponents
    {
        void clickByJS(IWebElement element);
        string getTextJS(IWebElement element);
        void execScript(string script, params object[] args);
        object execScriptRet(string script, params object[] args);
        void scrollPage(int hz, int ver);
        void scrollForElementVisibility(IWebElement element);
        void hoverOntoJS(IWebElement webElement);
    }
}
