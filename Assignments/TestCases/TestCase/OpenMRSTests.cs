using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumBase;
using System;

namespace TestCases
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
    class TestCaseCollection : SelActions
    {

        [OneTimeSetUp]
        public void setup()
        {
            open("https://demo.openmrs.org/openmrs/");
            waitForPageLoad();
        }

        [Test, Order(1)]
        public void TestLogin()
        {
            openWithCurrentDriver("https://demo.openmrs.org/openmrs/");
            waitForPageLoad();

            FindID("username").SendKeys("Admin");
            FindID("password").SendKeys("Admin123");

            FindID("Inpatient Ward").Click();
            FindID("loginButton").Click();

            waitForPageLoad();

            Assert.That(elementExists(XPath("//*[contains(text(),'Logged in') or text()='Logged in']")));
        }

        [Test, Order(2)]
        public void TestPatientRegistration()
        {
            openWithCurrentDriver("https://demo.openmrs.org/openmrs/");
            waitForPageLoad();

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

        [Test, Order(3)]
        public void TestPatientRecord()
        {
            openWithCurrentDriver("https://demo.openmrs.org/openmrs/coreapps/findpatient/findPatient.page?app=coreapps.findPatient");
            waitForPageLoad();

            Assert.That(FindAllBy(XPath("//*[@role='alert']//tr")).Count >= 1);
        }

        [Test, Order(4)]
        public void SearchPatientRecord()
        {
            openWithCurrentDriver("https://demo.openmrs.org/openmrs/coreapps/findpatient/findPatient.page?app=coreapps.findPatient");
            waitForPageLoad();

            FindID("patient-search").SendKeys("Dead Don Dilemma");
            waitForPageLoad();

            Assert.That(!elementExists(XPath("//*[@role='alert']//tr//td[@class='dataTables_empty']")));
        }

        [Test, Order(5)]
        public void ViewPatientRecord()
        {
            openWithCurrentDriver("https://demo.openmrs.org/openmrs/coreapps/findpatient/findPatient.page?app=coreapps.findPatient");
            waitForPageLoad();

            FindID("patient-search").SendKeys("Dead Don Dilemma");
            waitForPageLoad();
            FindID("patient-search").SendKeys(Keys.Enter);
            waitForPageLoad();

            Assert.AreNotEqual(getTextJS(FindXPath("//*[@class='float-sm-right']//span")), String.Empty);
        }

        [Test, Order(6)]
        public void BookAppointment()
        {
            openWithCurrentDriver("https://demo.openmrs.org/openmrs/coreapps/findpatient/findPatient.page?app=coreapps.findPatient");
            waitForPageLoad();

            FindID("patient-search").SendKeys("Dead Don Dilemma");
            waitForPageLoad();
            FindID("patient-search").SendKeys(Keys.Enter);
            waitForPageLoad();

            Assert.AreNotEqual(getTextJS(FindXPath("//*[@class='float-sm-right']//span")), String.Empty);

            FindTextTagless("Schedule Appointment").Click();
            waitForPageLoad();

            FindXPath("//*[@ng-model='appointmentType']").SendKeys("a");
            wait2s();
            FindXPath("//*[@ng-model='appointmentType']").SendKeys(Keys.Enter);

            Assert.That(false);
        }

        [Test, Order(7)]
        public void CaptureVitals()
        {
            openWithCurrentDriver("https://demo.openmrs.org/openmrs/coreapps/findpatient/findPatient.page?app=referenceapplication.vitals");
            waitForPageLoad();

            FindID("patient-search").SendKeys("Dead Don Dilemma");
            waitForPageLoad();
            FindID("patient-search").SendKeys(Keys.Enter);
            waitForPageLoad();

            Assert.That(false);
        }

        [Test,Order(8)]
        public void DeletePatient()
        {
            openWithCurrentDriver("https://demo.openmrs.org/openmrs/coreapps/findpatient/findPatient.page?app=coreapps.findPatient");
            waitForPageLoad();

            FindID("patient-search").SendKeys("Dead Don Dilemma");
            waitForPageLoad();
            FindID("patient-search").SendKeys(Keys.Enter);
            waitForPageLoad();

            FindText("div", "Delete Patient").Click();
            wait_5();
            switchToActive();

            FindID("delete-reason").SendKeys("random");
            clickByJS(FindXPath("//*[@class='confirm right']"));

            wait2s();

            waitForPageLoad();

            openWithCurrentDriver("https://demo.openmrs.org/openmrs/coreapps/findpatient/findPatient.page?app=coreapps.findPatient");

            waitForPageLoad();

            switchToActive();

            FindID("patient-search").SendKeys("Dead Don Dilemma");
            waitForPageLoad();

            Assert.That(elementExists(XPath("//*[@role='alert']//tr//td[@class='dataTables_empty']")));
        }

        [Test, Order(9)]
        public void TestLogout()
        {
            openWithCurrentDriver("https://demo.openmrs.org/openmrs/");
            waitForPageLoad();

            FindTextTagless("Logout").Click();
            waitForPageLoad();

            Assert.That(getDriver().Url.Contains("login.htm"));
        }

        [OneTimeTearDown]
        public void Exit()
        {
            exit();
        }
    }
}
