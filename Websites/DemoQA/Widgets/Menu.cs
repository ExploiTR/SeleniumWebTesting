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
    internal class Menu
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/menu");

            moveToMainItem();
            moveToSubItem();
            moveToSub_SubItem();

            driver.Quit();

            if (chain)
            {
                new SelectMenu().start();
            }
        }

        private void moveToSub_SubItem()
        {
            moveonto(driver.FindElement(By.XPath("//a[text()='Sub Sub Item 2']")));
        }

        private void moveToSubItem()
        {
            moveonto(driver.FindElement(By.XPath("//a[text()='SUB SUB LIST »']")));
        }

        private void moveToMainItem()
        {
            moveonto(driver.FindElement(By.XPath("//a[text()='Main Item 2']")));
        }
        private void moveonto(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }
    }
}
