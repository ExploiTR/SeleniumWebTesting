using System;
using OpenQA.Selenium;

namespace SeleniumBase
{
    internal class Test : SelActions
    {
        public static void Main(String[] args)
        {
            new Test().start();
        }

        private void start()
        {
            var linkOpt = new LinkOptions();
            linkOpt.Maximize = true;
            linkOpt.FullScreen = false;

            open("https://www.google.com",linkOpt);

            sendKeys(findXPath("//input[@title='Search']"),"mango");

            switchToActive();

            sendKeys(findXPath("//input[@title='Search']"), Keys.Enter);

            wait(2000);
            exit();
        }
    }
}
