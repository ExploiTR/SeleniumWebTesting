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
    internal class CheckBox
    {
        public void run(bool _continue)
        {

            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            try
            {

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/checkbox");

                Thread.Sleep(500);

                driver.FindElement(By.XPath("//button[@title='Expand all']")).Click(); //expand root

                Thread.Sleep(500);

                driver.FindElement(By.XPath("//button[@title='Collapse all']")).Click(); //collapse root

                Thread.Sleep(500);

                driver.FindElement(By.XPath("//span[text()='Home']")).Click();
                driver.FindElements(By.XPath("//button[@title='Toggle']"))[0].Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//span[text()='Desktop']")).Click();
                driver.FindElements(By.XPath("//button[@title='Toggle']"))[1].Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//span[text()='Notes']")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//span[text()='Documents']")).Click();
                driver.FindElements(By.XPath("//button[@title='Toggle']"))[2].Click();
                Thread.Sleep(2500);
                driver.FindElement(By.XPath("//span[text()='WorkSpace']")).Click();
                driver.FindElements(By.XPath("//button[@title='Toggle']"))[3].Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//span[text()='Angular']")).Click();

                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//span[text()='Angular']")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//span[text()='WorkSpace']")).Click();
                driver.FindElements(By.XPath("//button[@title='Toggle']"))[3].Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//span[text()='Documents']")).Click();
                driver.FindElements(By.XPath("//button[@title='Toggle']"))[2].Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//span[text()='Notes']")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//span[text()='Desktop']")).Click();
                driver.FindElements(By.XPath("//button[@title='Toggle']"))[1].Click();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//span[text()='Home']")).Click();
                driver.FindElements(By.XPath("//button[@title='Toggle']"))[0].Click();

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
                new RadioButton().run(_continue);
        }
    }
}
