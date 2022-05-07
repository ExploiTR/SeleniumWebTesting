using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace AutomationPractice.TestCases
{
    internal class TestCase2 : SelActions
    {
        public TestCase2()
        {
            open("http://automationpractice.com/index.php");

            trySignIn();
            TestCases();
        }

        private void TestCases()
        {
            FindID("email_create").SendKeys("invalid.exe");
            FindID("SubmitCreate").Click();
            wait3s();

            if (elementExists(By.XPath("//*[contains(text(),'Invalid email address') or text()='Invalid email address']")) &&
                FindTextTagless("Invalid email address").Displayed)
            {
                Console.WriteLine("Test Case Passed: Invalid Email Warning Visible.");
            }
        }

        private void trySignIn()
        {
            FindTextTagless("Sign in").Click();

            while (!elementExists(By.Id("email_create")))
            {
                wait_5();
            }
        }
    }
}
