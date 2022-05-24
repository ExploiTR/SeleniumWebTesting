using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using SeleniumExtras.PageObjects;
using PageGenerator.WrapperFactory;
using PageGenerator.PageObjects;

namespace PageGenerator.TestCases
{
    class LoginTest
    {
        [Test]
        public void Test2()
        {
            BrowserFactory.initBrowser("Firefox");

            BrowserFactory.loadApplication(ConfigurationManager.AppSettings["URL2"]);

            var Login = new LoginPage(BrowserFactory.driver);

            Login.LogIntoApplication("LoginTest");
        }
    }
}
