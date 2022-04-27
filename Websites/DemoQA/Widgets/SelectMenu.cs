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
    internal class SelectMenu
    {
        private static IWebDriver driver;
        public void start()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");

            pickOption();
            pickTitle();
            pickColor();
            pickMulColor();
            testStdMulSel();

            Console.ReadKey();

            driver.Quit();
        }

        private void testStdMulSel()
        {
            var yo = driver.FindElement(By.Id("cars"));

            Actions actions = new Actions(driver);

            actions.KeyDown(Keys.LeftControl)
                .MoveToElement(driver.FindElements(By.XPath("//select[@id='cars']//option"))[1])
                .Click()
                .MoveToElement(driver.FindElements(By.XPath("//select[@id='cars']//option"))[0])
                .Click()
                .Release().Build().Perform();
        }

        private void pickMulColor()
        {
            var z = driver.FindElement(By.XPath("//div[text()='Select...']"));
            z.Click();

            driver.FindElement(By.XPath("//input[@id='react-select-4-input']"))
                .SendKeys(Keys.ArrowDown + Keys.Enter + Keys.ArrowDown + Keys.Enter + Keys.ArrowDown + Keys.Enter + Keys.ArrowDown + Keys.Enter);
        }

        private void pickColor()
        {
            var f = driver.FindElement(By.Id("oldSelectMenu"));
            f.Click();
            f.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }

        private void pickTitle()
        {
            driver.FindElement(By.XPath("//div[text()='Select Title']"))
                .Click();

            Thread.Sleep(500);

            driver.FindElement(By.XPath("//input[@id='react-select-3-input']"))
                .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }

        private void pickOption()
        {
            driver.FindElement(By.XPath("//div[text()='Select Option']"))
                .Click();

            Thread.Sleep(500);

            driver.FindElement(By.XPath("//input[@id='react-select-2-input']"))
                .SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
        }
    }
}
