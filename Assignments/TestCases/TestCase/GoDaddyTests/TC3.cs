using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace TestCase.GoDaddyTests
{
    class TC3 : SelActions
    {
        /*
        * 3. Test Case - Open Godaddy.com and Validate Page Title
        * Steps to Automate:
        * 1. Launch browser of your choice say., Firefox, chrome etc.
        * 2. Open this URL - https://www.godaddy.com/
        * 3. Maximize or set size of browser window.
        * 4. Get Title of page and validate it with expected value.
        * 5. Get URL of current page and validate it with expected value.
        * 6. Get Page source of web page.
        * 7. And Validate that page title is present in page source.
        * 8. Close browser.
        * 
        */
        public TC3()
        {
            open("https://www.godaddy.com/");
            Assert.That(getCurrentPageTitle().Equals("Domain Names, Websites, Hosting & Online Marketing Tools - GoDaddy IN"));
            Assert.That(getCurrentPageUrl().Equals("https://www.godaddy.com/en-in"));
            exit();
        }
    }
}
