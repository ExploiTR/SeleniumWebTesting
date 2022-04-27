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
    internal class RadioButton
    {
        public void run(bool _continue)
        {
            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            try
            {

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/radio-button");

                Thread.Sleep(500);

                IWebElement YesBtn = driver.FindElement(By.Id("yesRadio"));
                executor.ExecuteScript("arguments[0].click()", YesBtn);

                Thread.Sleep(1000);

                IWebElement ImpressBtn = driver.FindElement(By.Id("impressiveRadio"));
                executor.ExecuteScript("arguments[0].click()", ImpressBtn);

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
                new WebTables().run(_continue);
        }
    }
}
