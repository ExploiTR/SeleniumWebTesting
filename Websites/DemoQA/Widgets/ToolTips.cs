using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Widgets
{
    internal class ToolTips
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/tool-tips");

            testHoverOnButton();
            testHoverOnEditText();
            testHoverOnTextItems();

            driver.Quit();

            if (chain)
            {
                new Menu().start(chain);
            }
        }

        private void testHoverOnTextItems()
        {
            hoverOnto(driver.FindElement(By.XPath("//a[text()='Contrary']")));
            Thread.Sleep(1000);
            hoverOnto(driver.FindElement(By.XPath("//a[text()='1.10.32']")));
        }

        private void testHoverOnEditText()
        {
            hoverOnto(driver.FindElement(By.Id("toolTipTextField")));
        }

        private void testHoverOnButton()
        {
            hoverOnto(driver.FindElement(By.Id("toolTipButton")));
        }

        private void hoverOnto(IWebElement webElement)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(webElement).Perform();
        }
    }
}
