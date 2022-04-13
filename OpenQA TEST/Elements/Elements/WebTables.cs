﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elements
{
    internal class WebTables
    {
        public void run(bool _continue)
        {
            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            try
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/webtables");

                Thread.Sleep(500);

                IWebElement searchBox = driver.FindElement(By.Id("searchBox"));
                searchBox.SendKeys("Cierra");
                Thread.Sleep(500);
                searchBox.Clear();
                Thread.Sleep(500);
                searchBox.SendKeys("45");
                Thread.Sleep(500);
                searchBox.Clear();
                Thread.Sleep(500);
                searchBox.SendKeys("2000");
                Thread.Sleep(500);
                searchBox.Clear();

                driver.FindElement(By.XPath("//span[contains(@class,'pageSizeOptions')]")).Click();
                Thread.Sleep(250);
                driver.FindElement(By.XPath("//option[@value='20']")).Click();
                executor.ExecuteScript("window.scrollBy(0,200)");
                Thread.Sleep(500);

                driver.FindElement(By.Id("addNewRecordButton")).Click();
                Thread.Sleep(100);
                driver.SwitchTo().ActiveElement();

                driver.FindElement(By.Id("firstName")).SendKeys("Nameless");
                driver.FindElement(By.Id("lastName")).SendKeys("Human");
                driver.FindElement(By.Id("userEmail")).SendKeys("nameless@human.exe");
                driver.FindElement(By.Id("age")).SendKeys("22");
                driver.FindElement(By.Id("salary")).SendKeys("9000");
                driver.FindElement(By.Id("department")).SendKeys("Automation Testing");

                Thread.Sleep(500);

                driver.FindElement(By.Id("submit")).Click();

                Thread.Sleep(1000);

                searchBox.SendKeys("Nameless");
                Thread.Sleep(500);
                searchBox.Clear();
                Thread.Sleep(500);
                searchBox.SendKeys("22");
                Thread.Sleep(500);
                searchBox.Clear();
                Thread.Sleep(500);
                searchBox.SendKeys("Automation");
                Thread.Sleep(500);
                searchBox.Clear();

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
                new Buttons().run(_continue);
        }
    }
}
