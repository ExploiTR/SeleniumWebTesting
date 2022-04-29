using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        ReadOnlyCollection<IWebElement> FindAllBy(By by);

        bool textEquals(By by, string verification);

        bool textEquals(IWebElement element, string verification);

        bool elementExists(By by);

        string getAttribute(IWebElement element, string attr);

        string getAttributeXpath(string Xpath, string attr);

        void clickByJS(IWebElement element);

        void click(By by);

        void click(IWebElement by);

        void sendKeys(By by, string key);

        void sendKeys(IWebElement by, string key);

        void clearAndSendKeys(IWebElement element, string key);

        void clearAndSendKeys(By by, string key);

        void clear(IWebElement element);
    }
}
