using OpenQA.Selenium;

namespace SeleniumBase
{
    interface IByWrapper
    {
        By ClassName(string classNameToFind);
        By CssSelector(string cssSelectorToFind);
        By Id(string idToFind);
        By LinkText(string linkTextToFind);
        By Name(string nameToFind);
        By PartialLinkText(string partialLinkTextToFind);
        By TagName(string tagNameToFind);
        By XPath(string xpathToFind);
    }
}
