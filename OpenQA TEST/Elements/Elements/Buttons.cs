using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elements
{
    internal class Buttons
    {
        public void run(bool _continue) {

            IWebDriver driver = new ChromeDriver();
            var executor = (IJavaScriptExecutor)driver;

            try
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/buttons");

                Actions actions = new Actions(driver);

                actions.DoubleClick(driver.FindElement(By.Id("doubleClickBtn"))).Perform();
                actions.ContextClick(driver.FindElement(By.Id("rightClickBtn"))).Perform();
                driver.FindElement(By.XPath("//button[text()='Click Me']")).Click();

                Console.WriteLine("Checks Successful!");

                Thread.Sleep(3000);

                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(5000);
                driver.Quit();
            }

            if (_continue)
                new Links().run(_continue);
        }
    }
}
