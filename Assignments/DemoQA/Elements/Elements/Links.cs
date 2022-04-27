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
    internal class Links
    {
        public void run(bool _continue) {
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/links");

                //driver.FindElement(By.XPath("//a[@id='simpleLink']")).Click();
                driver.FindElement(By.Id("simpleLink")).Click();
                Thread.Sleep(500);
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                Thread.Sleep(500);
                driver.Close();

                driver.SwitchTo().Window(driver.WindowHandles[0]);

                //driver.FindElement(By.XPath("//a[@id='dynamicLink']")).Click();
                driver.FindElement(By.Id("dynamicLink")).Click();
                Thread.Sleep(500);
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                Thread.Sleep(500);
                driver.Close();

                driver.SwitchTo().Window(driver.WindowHandles[0]);

                driver.FindElement(By.Id("created")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.Id("no-content")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.Id("moved")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.Id("bad-request")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.Id("unauthorized")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.Id("forbidden")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.Id("invalid-url")).Click();

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

            if (_continue) { 
                new BrokenLink().run(_continue);
            }
        }
    }
}
