using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace AutomationPractice.TestCases
{
    internal class TestCase4 : SelActions
    {
        public TestCase4()
        {
            setup();
            giveInputs();
            TestCase();
        }

        private void setup()
        {
            open("http://automationpractice.com/index.php?controller=authentication&back=my-account");
            FindID("email_create").SendKeys("sample5ethuji@gfoj.com");
            FindID("SubmitCreate").Click();
            wait5s();
        }

        private void TestCase()
        {
            var all = FindAllBy(By.XPath("//*[contains(text(),'invalid')]"));

            Console.WriteLine(all.Count == 8 ? "Test Case Passed : Errors visible." : "Test Case 4 Failed");
        }

        private void giveInputs()
        {
            clickByJS(FindID("id_gender1"));

            FindID("customer_firstname").SendKeys("234");
            FindID("customer_lastname").SendKeys("43675");
            FindID("email").Click();

            FindID("passwd").SendKeys("demopass");
            FindID("company").SendKeys("2345");

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

            FindID("address1").SendKeys("3452345$&%");
            wait_5();

            FindID("address2").SendKeys("2345^$&%");
            wait_5();

            FindID("city").SendKeys("8673^%&R$*");
            wait_5();

            FindID("id_state").Click();
            wait_5();
            sendKeysWithAction(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            FindID("postcode").SendKeys("8673^%&$*");
            wait_5();

            FindID("other").SendKeys("8673^%&R$*");
            wait_5();

            FindID("phone_mobile").SendKeys("8673^%&R$*");
            wait_5();

            FindID("submitAccount").Click();
            wait5s();
        }
    }
}
