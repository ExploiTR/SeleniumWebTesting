using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interaction
{
    internal class Sortable
    {
        private static IWebDriver driver;
        public void start(bool continue_)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/sortable");

            testNormalList();
            testGridList();

            driver.Quit();
        }

        private void testGridList()
        {
            driver.FindElement(By.Id("demo-tab-grid")).Click();
            Thread.Sleep(500);

            var item1 = driver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//div[contains(@class,'list-group-item')]"));
            Actions actions = new Actions(driver);

            actions.MoveToElement(item1[0])
                .ClickAndHold()
                .MoveToElement(item1[3])
                .MoveToElement(item1[4])
                .MoveToElement(item1[5])
                .MoveToElement(item1[8])
                .MoveToElement(item1[6])
                .MoveToElement(item1[2])
                .MoveToElement(item1[1])
                .Release()
                .Build()
                .Perform();
        }

        private void testNormalList()
        {
            var item1 = driver.FindElements(By.XPath("//div[@id='demo-tabpane-list']//div[contains(@class,'list-group-item')]"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(item1[1])
                .ClickAndHold()
                .MoveToElement(item1[3])
                .Release()
                .MoveToElement(item1[4])
                .ClickAndHold()
                .MoveToElement(item1[5])
                .Release()
                .MoveToElement(item1[0])
                .ClickAndHold()
                .MoveToElement(item1[3])
                .Release()
                .Build()
                .Perform();
        }
    }
}
