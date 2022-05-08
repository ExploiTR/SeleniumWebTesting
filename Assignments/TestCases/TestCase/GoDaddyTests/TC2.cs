using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace TestCase.GoDaddyTests
{
    class TC2 : SelActions
    {
        /*
        * 2. Test Case - Open Godaddy.com and Print it's Page title.
        * Steps to Automate:
        * 1. Launch browser of your choice say., Firefox, chrome etc.
        * 2. Open this URL - https://www.godaddy.com/
        * 3. Maximize or set size of browser window.
        * 4. Get Title of page and print it.
        * 4. Get URL of current page and print it.
        * 5. Close browser.
        */
        public  TC2()
        {
            open("https://www.godaddy.com/");
            print(getCurrentPageTitle());
            print(getCurrentPageUrl());
            exit();
        }
    }
}
