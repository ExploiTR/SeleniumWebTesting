using OpenQA.Selenium;
using System;
using NUnit.Framework;
using SeleniumBase;

namespace ConsoleApp1
{
    class Base : SelActions
    {
        [SetUp]
        public void Initialize()
        {
            open("http://automationpractice.com/index.php");
        }

        [Test]
        public void ExecuteTest()
        {
            FindXPath("//a[contains(@class, 'login')]").Click();
            sendKeys(XPath("//input[@name='email']"), "Pratim");

            wait2s();

            Console.WriteLine("Email Id Entered");

            getAction().KeyDown(Keys.Tab)
                  .KeyUp(Keys.Tab)
                  .Build()
                  .Perform();

            wait2s();

            Console.WriteLine("Tab Key pressed");
        }

        [TearDown]
        public void EndTest()
        {
            exit();
        }
    }
}
