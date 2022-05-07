using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace TestCase.OpenMRS
{
    /*Example-1: https://demo.openmrs.org/openmrs/
     * 
     * 
     * 1. Username/Password ::: Admin/Admin123
     * 2. Click on In-patient ward
     * 
     * Test Scenario’s:
     * 
     * Login
     * Logout
     * Register a Patient
     * Find Patient Record
     * View the Patient
     * Search a Patient
     * Book an Appointment
     * Capture Vitals
     * 
     */

    [TestFixture]
    class TestCase1 : SelActions
    {

        [SetUp]
        public void setup()
        {
            open("https://demo.openmrs.org/openmrs/");
            waitForPageLoad();
        }

        [Test]
        public void TestLogin()
        {
            FindID("username").SendKeys("Admin");
            FindID("password").SendKeys("Admin123");

            FindID("Inpatient Ward").Click();
            FindID("loginButton").Click();

            waitForPageLoad();

            Assert.That(elementExists(XPath("//*[contains(text(),'Logged in') or text()='Logged in']")));
        }

        [Test]
        public void TestPatientRegistration()
        {
            FindXPath("//*[contains(@id,'register')]").Click();

            waitForPageLoad();

            FindName("givenName").SendKeys("Dead");
            FindName("middleName").SendKeys("Don");
            FindName("familyName").SendKeys("Dilemma");

            FindID("next-button").Click();
            waitForPageLoad();

            FindID("gender-field").Click();

            sendKeysWithAction(Keys.ArrowDown + Keys.Enter);

            FindID("next-button").Click();
            waitForPageLoad();

            FindName("birthdateYears").SendKeys("95");
            FindName("birthdateMonths").SendKeys("11");

            FindID("next-button").Click();
            waitForPageLoad();

            FindID("address1").SendKeys("Sample Address, 123 Streeet i guess");
            FindID("address2").SendKeys("Is this a landmark");
            FindID("cityVillage").SendKeys("California");
            FindID("stateProvince").SendKeys("California");
            FindID("country").SendKeys("USA");
            FindID("postalCode").SendKeys("10001");

            FindID("next-button").Click();
            waitForPageLoad();

            FindName("phoneNumber").SendKeys("+1345123");

            FindID("next-button").Click();
            waitForPageLoad();

            FindName("relationship_type").Click();
            sendKeysWithAction(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            FindXPath("//input[@ng-model='relationship.name']").SendKeys("whoisthat");

            FindID("next-button").Click();
            waitForPageLoad();

            FindID("submit").Click();
            waitForPageLoad();
            Assert.AreNotEqual(getTextJS(FindXPath("//*[@class='float-sm-right']//span")), String.Empty);
        }
    }
}
