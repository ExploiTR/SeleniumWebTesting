using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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

            open("https://www.google.com");

            sendKeys(FindXPath("//input[@title='Search']"), "mango");

            wait(1000);

            switchToActive();

            click(FindXPath("//input[@name='btnK']"));

            wait(5000);
            exit();
        }
    }
}
