using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using POM1.DataAccess;

namespace POM1.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "userName")]
        [CacheLookup]
        private IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        [CacheLookup]
        private IWebElement SubmitButton { get; set; }

        public void LogIntoApplication(string TestName)
        {
            //Username.SendKeys("aria");
            //Password.SendKeys("@riaLabel2022");

            var UserData = ExcelDataAccess.GetTestData(TestName);

            Username.SendKeys(UserData.username);
            Password.SendKeys(UserData.password);

            SubmitButton.Click();
        }
    }
}
