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
    internal class Selectable
    {
        private static IWebDriver driver;
        public void start(bool continue_)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/selectable");

            testNormalList();
            testGridList();

            driver.Quit();

            if (continue_)
            {
                new Resizable().start(continue_);
            }
        }

        private void testGridList()
        {
            driver.FindElement(By.Id("demo-tab-grid")).Click();
            Thread.Sleep(500);

            var item1 = driver.FindElements(By.XPath("//div[@id='demo-tabpane-grid']//li[contains(@class,'list-group-item')]"));
            Actions actions = new Actions(driver);

            actions.MoveToElement(item1[0])
                .Click()
                .MoveToElement(item1[3])
                .Click()
                .MoveToElement(item1[4])
                .Click()
                .MoveToElement(item1[5])
                .Click()
                .MoveToElement(item1[8])
                .Click()
                .MoveToElement(item1[6])
                .Click()
                .MoveToElement(item1[2])
                .Click()
                .MoveToElement(item1[1])
                .Click()
                .MoveToElement(item1[0])
                .Click()
                .MoveToElement(item1[3])
                .Click()
                .MoveToElement(item1[4])
                .Click()
                .MoveToElement(item1[5])
                .Click()
                .MoveToElement(item1[8])
                .Click()
                .MoveToElement(item1[6])
                .Click()
                .MoveToElement(item1[2])
                .Click()
                .MoveToElement(item1[1])
                .Click()
                .Release()
                .Build()
                .Perform();
        }

        private void testNormalList()
        {
            var item1 = driver.FindElements(By.XPath("//div[@id='demo-tabpane-list']//li[contains(@class,'list-group-item')]"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(item1[0])
                .Click()
                .MoveToElement(item1[1])
                .Click()
                .MoveToElement(item1[2])
                .Click()
                .MoveToElement(item1[3])
                .Click()
                .MoveToElement(item1[0])
                .Click()
                .MoveToElement(item1[1])
                .Click()
                .MoveToElement(item1[2])
                .Click()
                .MoveToElement(item1[3])
                .Click()
                .Release()
                .Build()
                .Perform();
        }
    }
}
