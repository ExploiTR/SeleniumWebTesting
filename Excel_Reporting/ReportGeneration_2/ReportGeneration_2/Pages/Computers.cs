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
    public class Computers
    {
        public Computers()
        {
            driver = null;
        }

        public Computers(IWebDriver WebDriver)
        {
            driver = WebDriver;
        }

        // Driver
        IWebDriver driver;

        //Locator
        [FindsBy(How = How.Id, Using = "small-searchterms")]
        private IWebElement SearchInput;

        
        [FindsBy(How = How.XPath, Using = "//input[@value=search]")]
        private IWebElement SearchButton;

        
        // Actions
        public Computers isAt()
        {
            Assert.IsTrue(driver.Title.Equals("nopCommerce demo store. Computers"));

            return this;
        }

        public Computers EnterSearchText(string searchText)
        {
            SearchInput.SendKeys(searchText);

            return this;
        }

        public Computers clickSearch()
        {
            SearchButton.Click();

            return this;
        }
    }
}
