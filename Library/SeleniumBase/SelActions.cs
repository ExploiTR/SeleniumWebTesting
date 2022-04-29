using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBase
{
    internal class SelActions
    {
        private IWebDriver driver = null;
        private IWebDriver lastInstance = null;
        private void init()
        {
            if (driver == null)
                driver = new ChromeDriver();
        }

        private void initNewWindow()
        {
            if (driver == null)
                driver = new ChromeDriver();
            else {
                lastInstance = driver;
                driver = new ChromeDriver();
            }
        }

        protected IWebDriver getDriver()
        {
            return driver;
        }

        protected void open(string link)
        {
            init();
            driver.Navigate().GoToUrl(link);
        }

        protected void openNewWindow(string link)
        {
            initNewWindow();
            driver.Navigate().GoToUrl(link);
        }

        protected void close() {
            if (driver != null)
                driver.Close();
            if (lastInstance != null)
                lastInstance.Close();
        }

        protected void exit() {
            if (driver != null)
                driver.Quit();
            if (lastInstance != null)
                lastInstance.Quit();
        }

        protected void wait(int time) {
            Thread.Sleep(time);
        }

        protected void open(string link, LinkOptions options)
        {
            init();
            if (options.FullScreen)
            {
                driver.Manage().Window.FullScreen();
            }
            if (options.Maximize)
            {
                driver.Manage().Window.FullScreen();
            }
            driver.Navigate().GoToUrl(link);
        }

        protected IWebElement findID(string id) {
            return driver.FindElement(By.Id(id));
        }
        protected IWebElement findXPath(string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }
        protected IWebElement findName(string name)
        {
            return driver.FindElement(By.Name(name));
        }
        protected IWebElement findCSS(string css)
        {
            return driver.FindElement(By.CssSelector(css));
        }
        protected IWebElement findTag(string id)
        {
            return driver.FindElement(By.TagName(id));
        }
        protected IWebElement findClass(string class_)
        {
            return driver.FindElement(By.ClassName(class_));
        }
        protected IWebElement findLinkText(string tlink)
        {
            return driver.FindElement(By.LinkText(tlink));
        }
        protected IWebElement findPartialLinkText(string plt)
        {
            return driver.FindElement(By.PartialLinkText(plt));
        }


        protected void click(By by)
        {
            driver.FindElement(by).Click();
        }

        protected void click(IWebElement by)
        {
            by.Click();
        }

        protected void sendKeys(By by, string key)
        {
            driver.FindElement(by).SendKeys(key);
        }

        protected void sendKeys(IWebElement by, string key)
        {
            by.SendKeys(key);
        }

        protected void switchToActive(){
            driver.SwitchTo().ActiveElement();
        }

        protected void switchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }

        protected bool textEquals(By by, string verification)
        {
            try
            {
                return driver.FindElement(by).Text.Equals(verification);
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected bool validElement(By by)
        {
            try
            {
                var x = driver.FindElement(by);
                return x.Displayed;    
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
