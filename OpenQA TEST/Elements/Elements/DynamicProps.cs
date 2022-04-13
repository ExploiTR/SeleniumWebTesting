using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace Elements
{
    internal class DynamicProps
    {
        public void run()
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/dynamic-properties");

                IWebElement enableAfter5 = driver.FindElement(By.Id("enableAfter"));
                IWebElement coloredButton = driver.FindElement(By.Id("colorChange"));
                ReadOnlyCollection<IWebElement> visibleAfter5 = driver.FindElements(By.Id("visibleAfter"));

                string initialButtonColor = coloredButton.GetCssValue("color");

                Assert.IsFalse(enableAfter5.Enabled);
                Assert.IsTrue(visibleAfter5.Count == 0);

                Thread.Sleep(5100);

                ReadOnlyCollection<IWebElement> visibleAfter5_ = driver.FindElements(By.Id("visibleAfter"));

                Assert.IsTrue(enableAfter5.Enabled);
                Assert.IsTrue(visibleAfter5_.Count > 0);
                Assert.AreNotEqual(initialButtonColor,coloredButton.GetCssValue("color"));

                Console.WriteLine("Checks Successful!");

                Thread.Sleep(3000);

                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(5000);
            }
            driver.Quit();
        }
    }
}
