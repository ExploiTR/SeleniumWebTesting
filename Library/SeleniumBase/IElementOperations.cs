using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace SeleniumBase
{
    interface IElementOperations
    {
        IWebElement FindID(string id);
        IWebElement FindXPath(string xpath);
        IWebElement FindName(string name);
        IWebElement FindCSS(string css);
        IWebElement FindTag(string id);
        IWebElement FindClass(string class_);
        IWebElement FindLinkText(string tlink);
        IWebElement FindPartialLinkText(string plt);
        IWebElement FindWithInElement(By by, IWebElement element);
        IWebElement FindText(string tag, string text);
        IWebElement FindTextTagless(string text);
        IWebElement FindClassesTagLess(string className);
        IWebElement FindTitleTagless(string title);

        ReadOnlyCollection<IWebElement> FindAllBy(By by);

        bool textEquals(By by, string verification);

        bool textEquals(IWebElement element, string verification);

        bool elementExists(By by);

        string getAttribute(IWebElement element, string attr);

        string getAttributeXpath(string Xpath, string attr);

        void click(By by);

        void click(IWebElement by);

        void sendKeys(By by, string key);

        void sendKeys(IWebElement by, string key);

        void clearAndSendKeys(IWebElement element, string key);

        void clearAndSendKeys(By by, string key);

        void clear(IWebElement element);

        void clickAndThenSendKeys(IWebElement element, string combo);
    }
}
