using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ReportingLibrary;
using SeleniumHelperLibrary;

namespace ReportGeneration_2
{
    [TestClass]
    public abstract class TestBase
    {
        protected Browsers browser;
        protected Pages pages;
        protected ExtentReportsHelper extent;

        public void SetUpReporter()
        {
            extent = new ExtentReportsHelper();
        }

        [SetUp]
        public void StartUpTest()
        {
            browser = new Browsers();
            browser.Init();

            pages = new Pages(browser);

        }

        [TearDown]
        public void EndTest()
        {
            browser.Close();
        }
    }
}
