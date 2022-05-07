using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumBase
{
    interface IActionComponents
    {
        void clickWithAction(IWebElement element);

        void doubleClick(IWebElement element);

        void contextClick(IWebElement element);

        void controlClick(IWebElement element);

        void testHorizontalMovement(IWebElement element, int minPX, int maxPX);

        void testVerticalMovement(IWebElement element, int minPY, int maxPY);

        void squareMovement(IWebElement element, int minPX, int maxPX, int minPY, int maxPY);

        void dragAndDrop(IWebElement movable, IWebElement container);

        void dragAndDropOffset(IWebElement movable, int offX, int offY);

        void sendKeysWithAction(string key);

        void PressKeys(IWebElement element, string key);

        void releaseKeys(IWebElement element, string key);

        void keyStroke(IWebElement element, string key);

        Actions moveToElementAndClick(IWebElement webElement);

        void hoverOnto(IWebElement webElement);
    }
}
