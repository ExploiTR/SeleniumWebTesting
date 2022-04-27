using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Login
    {
        private static IWebDriver driver;
        private static readonly string u_name = "BassettiTest";
        private static readonly string u_password = "Bassetti@2022";
        public void start()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/login");

            setInput();
            login();
            explore();

            driver.Quit();
        }

        private void explore()
        {
            new BookStore().explore(driver);
        }

        private void login()
        {
            driver.FindElement(By.Id("login")).Click();
            Thread.Sleep(2500);
        }

        private void setInput()
        {
            driver.FindElement(By.Id("userName")).SendKeys(u_name);
            driver.FindElement(By.Id("password")).SendKeys(u_password);
        }
    }
}
