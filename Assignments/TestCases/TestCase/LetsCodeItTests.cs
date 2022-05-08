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
    class LetsCodeItTests : SelActions
    {

        [OneTimeSetUp]
        public void setup()
        {
            open("https://courses.letskodeit.com/practice");
        }

        [Test, Order(1)]
        public void TestRadios()
        {
            FindID("bmwradio").Click();
            wait1s();
            FindID("benzradio").Click();
            wait1s();
            FindID("hondaradio").Click();
        }

        [Test, Order(2)]
        public void TestSelect()
        {
            FindID("carselect").Click();
            FindID("carselect").SendKeys(Keys.ArrowDown + Keys.Enter);
        }

        [Test, Order(3)]
        public void TestMulSelect()
        {
            var all = FindAllBy(XPath("//*[@id='multiple-select-example']//option"));

            getAction().KeyDown(Keys.LeftControl)
                .Click(all[0])
                .Click(all[1])
                .Click(all[2]).KeyUp(Keys.LeftControl).Build().Perform();
        }

        [Test, Order(4)]
        public void TestCheckBoxes()
        {
            FindID("bmwcheck").Click();
            wait1s();
            FindID("benzcheck").Click();
            wait1s();
            FindID("hondacheck").Click();
        }

        [Test, Order(5)]
        public void TestNewWindows()
        {
            FindID("openwindow").Click();
            wait_5();
            Assert.That(getDriver().WindowHandles.Count == 2);
            switchToWindow(1);
            wait1s();
            close();
            switchToWindow(0);
            switchToDefault();
            Assert.That(getDriver().WindowHandles.Count == 1);
        }

        [Test, Order(6)]
        public void TestNewTabs()
        {
            FindID("opentab").Click();
            wait_5();
            Assert.That(getDriver().WindowHandles.Count == 2);
            switchToWindow(1);
            wait1s();
            close();
            switchToWindow(0);
            switchToDefault();
            Assert.That(getDriver().WindowHandles.Count == 1);
        }

        [Test, Order(7)]
        public void TestAlert()
        {
            FindID("name").SendKeys("Aceu");
            FindID("alertbtn").Click();
            wait_5();
            var al = switchToAlert();
            Assert.That(al.Text.Contains("Aceu"));
            al.Accept();
        }

        [Test, Order(8)]
        public void TestTable()
        {
            Assert.That(elementExists(XPath("//table[@id='product']//tr//td[@class='author-name'][1]")));
        }

        [Test, Order(9)]
        public void TestEnableDisableInput()
        {
            FindID("enabled-button").Click();

            FindID("enabled-example-input").SendKeys("Test and Text");
            wait_5();
            Assert.That(FindID("enabled-example-input").GetAttribute("value").Equals("Test and Text"));

            FindID("disabled-button").Click();
            wait5s();

            try
            {
                FindID("enabled-example-input").SendKeys("and something else");
                Assert.That(false);
            }
            catch (Exception) {
                Assert.That(true);
            }
        }

        [Test, Order(10)]
        public void TestDisplayElement()
        {
            Assert.That(FindID("displayed-text").Displayed);

            FindID("hide-textbox").Click();

            wait_5();

            Assert.That(!FindID("displayed-text").Displayed);
        }

        [Test, Order(11)]
        public void TestHoverElement()
        {
            hoverOnto(FindID("mousehover"));
            wait_5();
            switchToActive();
            wait_5();
            Assert.That(elementExists(XPath("//*[text()='Reload']")));
        }

        [OneTimeTearDown]
        public void Exit()
        {
            exit();
        }
    }
}
