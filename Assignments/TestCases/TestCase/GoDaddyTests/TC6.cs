using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace TestCase.GoDaddyTests
{
    class TC6 : SelActions
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
        public TC6()
        {
            open("https://godaddy.com/");

            string webName = genRandWebName();
            print(webName);

            waitForPageLoad();

            FindXPath("//*[contains(text(),'Domains')][1]").Click();
            switchToActive();
            wait_5();
            FindTextTagless("Domain Name Search").Click();

            waitForPageLoad();

            Assert.That(getCurrentPageTitle().Equals("Domain Name Search - Buy and Register Available Domains - GoDaddy IN"));
            print(getCurrentPageTitle());

            Assert.That(elementExists(XPath("//input[@name='domainToCheck']")));

            var sIn = FindXPath("//input[@name='domainToCheck']");
            Assert.That(sIn.Enabled);

            sIn.SendKeys(webName);

            Assert.That(elementExists(XPath("//*[@class='searchText']")));
            FindXPath("//*[@class='searchText']").Click();

            waitForPageLoad();

            Assert.That(elementExists(XPath("//*[@aria-label='Add " + webName + " to cart']")));
            Assert.That(elementExists(XPath("//*[@data-cy='availableCard']//*[@data-cy='price-block'][1]")));
            exit();
        }

        string genRandWebName()
        {
            return "website" + new Random().Next(99, 9999) + ".in";
        }
    }
}
