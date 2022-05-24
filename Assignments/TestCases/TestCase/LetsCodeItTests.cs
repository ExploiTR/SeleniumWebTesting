using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using SeleniumBase;
using System.Diagnostics;
using Assert = NUnit.Framework.Assert;

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

        public static ExtentTest Test;
        public static ExtentReports Extent;

        [OneTimeSetUp]
        public void setup()
        {
            open("https://courses.letskodeit.com/practice");

            Extent = new ExtentReports();

            var HtmlReporter = new ExtentHtmlReporter(@"D:\ReportsResults\Report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");

            Extent.AttachReporter(HtmlReporter);

            Test = Extent.CreateTest("T001");
            Test.Info("LetsKodeIT");
            
        }

        [Test, Order(1)]
        public void TestRadios()
        {
            FindID("bmwradio").Click();
            wait1s();
            FindID("benzradio").Click();
            wait1s();
            FindID("hondaradio").Click();

            Test.CreateNode("TestRadios()", "Method").Pass("Pass");
        }

        [Test, Order(2)]
        public void TestSelect()
        {
            FindID("carselect").Click();
            FindID("carselect").SendKeys(Keys.ArrowDown + Keys.Enter);

            Test.CreateNode("TestSelect()", "Method").Pass("Pass");
        }

        [Test, Order(3)]
        public void TestMulSelect()
        {
            var all = FindAllBy(XPath("//*[@id='multiple-select-example']//option"));

            getAction().KeyDown(Keys.LeftControl)
                .Click(all[0])
                .Click(all[1])
                .Click(all[2]).KeyUp(Keys.LeftControl).Build().Perform();


            Test.CreateNode("TestMulSelect()", "Method").Pass("Pass");
        }

        [Test, Order(4)]
        public void TestCheckBoxes()
        {
            FindID("bmwcheck").Click();
            wait1s();
            FindID("benzcheck").Click();
            wait1s();
            FindID("hondacheck").Click();


            Test.CreateNode("TestCheckBoxes()", "Method").Pass("Pass");
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


            Test.CreateNode("TestWindows()", "Method").Pass("Pass");
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


            Test.CreateNode("TestNewTabs()", "Method").Pass("Pass");
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


            Test.CreateNode("TestAlert()", "Method").Pass("Pass");
        }

        [Test, Order(8)]
        public void TestTable()
        {
            Assert.That(elementExists(XPath("//table[@id='product']//tr//td[@class='author-name'][1]")));

            Test.CreateNode("TestTable()", "Method").Pass("Pass");
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

            Test.CreateNode("TestEnableDisableInput()", "Method").Pass("Pass");
        }

        [Test, Order(10)]
        public void TestDisplayElement()
        {
            Assert.That(FindID("displayed-text").Displayed);

            FindID("hide-textbox").Click();

            wait_5();

            Assert.That(!FindID("displayed-text").Displayed);


            Test.CreateNode("TestDisplayElement()", "Method").Pass("Pass");
        }

        [Test, Order(11)]
        public void TestHoverElement()
        {
            hoverOnto(FindID("mousehover"));
            wait_5();
            switchToActive();
            wait_5();
            Assert.That(elementExists(XPath("//*[text()='Reload']")));


            Test.CreateNode("TestHoverElement()", "Method").Pass("Pass");
        }

        [OneTimeTearDown]
        public void Exit()
        {
            Test.Log(Status.Pass, "Test Pass");
            Extent.Flush();
            exit();
            wait1s();

            Process.Start("CMD.exe", "/C start D:\\ReportsResults\\index.html");
        }
    }
}
