using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace TestCase.GoDaddyTests
{
    class TC5 : SelActions
    {
        /*
         * Test Case - Automate all the menu links of godaddy.com with Selenium.
         * Steps to Automate:
         * 1. Launch browser of your choice like, firefox, chrome etc., using selenium webdriver.
         * 2. Open website url - https://godaddy.com/
         * 3. Maximize browser window.
         * 4. Set timeout using implicit wait command of Selenium Webdriver.
         * 5.Click on the first link from the menu, it will open up the sub-menu with multiple sub-menu links.
         * 6. Click on the first sub-menu link.
         * 7. Get the page title and validate it.
         * 8. Go back to the home page by clicking on the GoDaddy logo.
         * 9. Repeat the steps 5 to 8 and cover all the menu and sub-menu items present one by one.
         * 
         */
        public TC5()
        {
            open("https://godaddy.com/");

            waitForPageLoad();

            FindAllBy(XPath("//*[@class='cms-nav']//li[contains(@class,'menu') and not ( contains(@class,'hide'))]"))[0].Click();
            switchToActive();
            wait_5();
            FindAllBy(XPath("//*[@class='tray-content']//ul[@aria-expanded='true']//li//a"))[0].Click();

            waitForPageLoad();

            Assert.That(getCurrentPageTitle().Equals("Domain Name Search - Buy and Register Available Domains - GoDaddy IN"));

            FindXPath("//*[@aria-label='GoDaddy']").Click();

            waitForPageLoad();

            Assert.That(getCurrentPageUrl().Equals("https://www.godaddy.com/en-in"));

            exit();
        }
    }
}
