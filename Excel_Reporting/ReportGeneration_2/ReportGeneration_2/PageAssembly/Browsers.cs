using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReportingLibrary;
using System.Configuration;

namespace Test
{
    public class Browsers
    {
        private IWebDriver driver;
        private string baseURL;
        private string browser;
        private ExtentReportsHelper extentReportsHelper;

        public Browsers(ExtentReportsHelper reportsHelper)
        {
            baseURL = ConfigurationManager.AppSettings["url"];

            browser = ConfigurationManager.AppSettings["browser"];

            extentReportsHelper = reportsHelper;
        }

        public void Init()
        {
            driver = new ChromeDriver();

            extentReportsHelper.SetStepStatusPass("Browser started.");
            driver.Manage().Window.Maximize();
            extentReportsHelper.SetStepStatusPass("Browser maximized.");
            GoTo(baseURL);
        }

        public string Title { get { return driver.Title; } }
       
        public IWebDriver getDriver { get { return driver; } }

        public void GoTo(string url)
        {
            driver.Url = url;
            extentReportsHelper.SetStepStatusPass($"Browser navigated to the url [{url}].");
        }

        public void Close()
        {
            driver.Quit();
            extentReportsHelper.SetStepStatusPass($"Browser closed.");
        }
    }
}
