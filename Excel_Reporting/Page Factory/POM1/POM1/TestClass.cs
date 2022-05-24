using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM1.PageObjects;
using System.Configuration;
using POM1.WrapperFactory;

namespace POM1
{
    // We can store connection string in app config
    // We can store target URL in app config
    // We can store different types of credentials in app config
    // app config can be internal or external


    public class TestClass
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            //driver.Url = "https://demoqa.com/text-box";
            //driver.Url = ConfigurationManager.AppSettings["URL1"];

            BrowserFactory.initBrowser("Firefox");

            BrowserFactory.loadApplication(ConfigurationManager.AppSettings["URL1"]);

            var TextBox = new TextBoxPage(driver);

            TextBox.FirstName.SendKeys("Aria");
            
            TextBox.Email.SendKeys("aria@gmail.com");
            
            TextBox.CA.SendKeys("Current Address");
            
            TextBox.PA.SendKeys("Permanent Address");

            TextBox.ClickSubmitButton();
        }

        [Test]
        public void Test2()
        {
            //driver.Url = "https://demoqa.com/login";

            driver.Url = ConfigurationManager.AppSettings["URL2"];

            var Login = new LoginPage(driver);

            Login.LogIntoApplication("LoginTest");

            //PageFactory.InitElements(driver, Login);

            //Login.Username.SendKeys("aria");

            //Login.Password.SendKeys("@riaLabel2022");

            //Login.SubmitButton.Click();
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
