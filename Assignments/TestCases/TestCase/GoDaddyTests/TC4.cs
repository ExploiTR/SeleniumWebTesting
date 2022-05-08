using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace TestCase.GoDaddyTests
{
    class TC4 : SelActions
    {
        /*
         * 4. Test Case - Automate the first menu link of godaddy.com with Selenium.
         * Steps to Automate:
         * 1. Launch browser of your choice like, firefox, chrome etc., usingselenium webdriver.
         * 2. Open website url - https://godaddy.com/
         * 3. Maximize browser window.
         * 4. Set timeout using implicit wait command of Selenium Webdriver.
         * 5. Click on the first menu link, which is 'Domains'. It will open up a sub-menu, click on the 'Domain Name Search' link from the sub-menu.
         * 6. Now, we'll get the value of the Page title manually before automating, just to know what should be the expected out put of our script. Following are the steps to automate it:
         * Right click on Domain Name Search page and click on 'Inspect' option.
         * It'll open up the html viewer of that page.
         * Under the 'Elements' tab, search for "<head>" tag and if you find it. Then search for "<title>" tag.
         * Copy the text written inside pair of "<title> and </title>" tags.
         * In the following pic, value of the title is "Domain Name Search | Check Domain Availability - GoDaddy IN". This is should be our expected value.
         * 7. Get the value of title of 'Domain Name Search' page using Selenium Webdriver's command in your script and print it.
         * 8. We already know the expected value, we'll match value fetched in step 7 with our expected value, if it matches print pass either fail.
         */
        public TC4()
        {
            open("https://godaddy.com/");

            waitForPageLoad(); 

            FindXPath("//*[contains(text(),'Domains')][1]").Click();
            switchToActive();
            FindTextTagless("Domain Name Search").Click();

            waitForPageLoad();

            Assert.That(getCurrentPageTitle().Equals("Domain Name Search - Buy and Register Available Domains - GoDaddy IN"));
            print(getCurrentPageTitle());

            exitPrompt();
        }
    }
}
