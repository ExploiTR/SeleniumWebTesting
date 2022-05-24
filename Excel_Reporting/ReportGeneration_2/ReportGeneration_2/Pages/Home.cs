using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReportGeneration_2
{
    public class Home
    {
        // Driver
        IWebDriver driver;

        public Home()
        {
            driver = null;
        }

        public Home(IWebDriver WebDriver)
        {
            driver = WebDriver;
        }

        // Locator
        [FindsBy(How = How.XPath, Using = "//ul[@class='top-menu notmobile']//a[@href='/computers']")]
        private IWebElement ComputerLink;


        // Actions
        public Home isAt()
        {
            Assert.IsTrue(driver.Title.Equals("nopCommerce demo store"));

            return this;
        }

        public Home goToComputers()
        {
            ComputerLink.Click();

            return this;
        }
    }
}
