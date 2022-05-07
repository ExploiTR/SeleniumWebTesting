using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace AutomationPractice.TestCases
{
    internal class TestCase1 : SelActions
    {
        public TestCase1()
        {
            open("http://automationpractice.com/index.php");
            signUp();
            verifyTestCase();
        }

        private void verifyTestCase()
        {
            int waitMax = 10;
            while (!getDriver().Url.Contains("controller=my-account"))
            {
                wait1s();
                waitMax--;
                if (waitMax == 0)
                    break;
            }

            if (elementExists(By.XPath("//p[contains(text(),'Welcome to your account')]")))
            {
                Console.WriteLine("User Verified,Test case Passed");
            }
            else
            {
                Console.WriteLine("User Verification Failed,Test case Failed");
            }
        }

        private void signUp()
        {
            open("http://automationpractice.com/index.php?controller=authentication&back=my-account");

            FindID("email_create").SendKeys("trennis.jazzx@whoisox.com");

            FindID("SubmitCreate").Click();

            while (!elementExists(By.XPath("//h3[text()='Your personal information']")))
            {
                wait_5();
                switchToActive();
            }

            clickByJS(FindID("id_gender1"));

            FindID("customer_firstname").SendKeys("Pratim");
            FindID("customer_lastname").SendKeys("Majumder");
            FindID("email").Click();

            FindID("passwd").SendKeys("demopass");
            FindID("company").SendKeys("Bassetti");

            wait3s();

            FindID("days").Click();
            FindID("days").Click();
            wait3s();
            sendKeysWithAction(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            FindID("months").Click();
            wait_5();
            sendKeysWithAction(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            FindID("years").Click();
            wait_5();
            sendKeysWithAction(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            FindID("newsletter").Click();
            FindID("optin").Click();

            FindID("address1").SendKeys("not kolkata");
            wait_5();

            FindID("address2").SendKeys("123 stresst");
            wait_5();

            FindID("city").SendKeys("Kolkata");
            wait_5();

            FindID("id_state").Click();
            wait_5();
            sendKeysWithAction(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            FindID("postcode").SendKeys("11111");
            wait_5();

            FindID("other").SendKeys("nothing to say much");
            wait_5();

            FindID("phone_mobile").SendKeys("911");
            wait_5();

            wait3s();
            FindID("submitAccount").Click();
        }
    }
}
