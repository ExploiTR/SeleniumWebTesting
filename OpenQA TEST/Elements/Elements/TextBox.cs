using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elements
{
    internal class TextBox
    {
        public void run(bool _continue)
        {
            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            try
            {

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/text-box");

                Thread.Sleep(500);

                driver.FindElement(By.Id("userName")).SendKeys("Pratim Majumder");
                driver.FindElement(By.Id("userEmail")).SendKeys("majumder@gmail.com");
                driver.FindElement(By.Id("currentAddress")).SendKeys("India");
                driver.FindElement(By.Id("permanentAddress")).SendKeys("WB, India");

                IWebElement submitButton = driver.FindElement(By.Id("submit"));

                do
                {
                    executor.ExecuteScript("window.scrollBy(0,1)");
                } while (!submitButton.Displayed || !submitButton.Enabled);

                Thread.Sleep(500);

                submitButton.Click();

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
                new CheckBox().run(_continue);
        }
    }
}
