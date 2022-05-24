using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using SeleniumExtras.PageObjects;
using POM1.WrapperFactory;
using POM1.PageObjects;

namespace POM1.TestCases
{
    class LoginTest: BrowserFactory
    {
        [Test]
        public void Test2()
        {

            BrowserFactory.initBrowser("Chrome");

            BrowserFactory.loadApplication(ConfigurationManager.AppSettings["URL2"]);
    
            var Login = new LoginPage(driver);

            Login.LogIntoApplication("LoginTest");
        }
    }
}
