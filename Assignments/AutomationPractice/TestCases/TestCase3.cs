using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace AutomationPractice.TestCases
{
    internal class TestCase3 : SelActions
    {
        public TestCase3()
        {
            openSignInPage();
            fillUpPage();
            TestCase();
        }

        private void TestCase()
        {
            Console.WriteLine(elementExists(By.XPath("//*[contains(text(),'There are 8 errors') or text()='There are 8 errors']")) ?
                "Test Case Passed : Errors visible." : "Test Case Failed");
        }

        private void fillUpPage()
        {
            FindID("email_create").SendKeys("test@sampleZ.com");
            wait_5();
            FindID("SubmitCreate").Click();

            while (!elementExists(By.Id("submitAccount")))
            {
                wait_5();
            }

            FindID("submitAccount").Click();
            wait3s();
        }

        private void openSignInPage()
        {
            open("http://automationpractice.com/index.php");

            FindTextTagless("Sign in").Click();

            while (!elementExists(By.Id("email_create")))
            {
                wait_5();
            }
        }
    }
}
