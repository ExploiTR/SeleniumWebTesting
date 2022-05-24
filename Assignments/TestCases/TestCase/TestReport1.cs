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

namespace TestCases
{
    [TestClass]
    public class TestReport1 : SelActions
    {

        public static ExtentTest Test;
        public static ExtentReports Extent;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            Extent = new ExtentReports();

            var HtmlReporter = new ExtentHtmlReporter(@"D:\ReportsResults\Report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");

            Extent.AttachReporter(HtmlReporter);
        }

        [Test]
        public void BrowserTest()
        {
            Test = Extent.CreateTest("T001").Info("LoginTest");

            open("https://demoqa.com/login");

            Test.Log(Status.Info, "GoToUrl");

            string username = "aria";
            string password = "@riaLabel2022";

            FindID("userName").SendKeys(username);
            FindID("password").SendKeys(password);
            FindID("login").Click();

            try
            {
                IWait<IWebDriver> Wait = new WebDriverWait(getDriver(), TimeSpan.FromSeconds(1));

                Wait.Until(driver1 => elementExists(By.XPath("//div[text()='Profile']")));

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }


        [OneTimeTearDown]
        public void ExtentClose()
        {
            Extent.Flush();
            exit();
            wait1s();

            Process.Start("CMD.exe","/C start D:\\ReportsResults\\index.html");
        }

    }
}
