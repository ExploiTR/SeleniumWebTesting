using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;

namespace POM1.PageObjects
{
    class TextBoxPage
    {
        private IWebDriver driver;

        public TextBoxPage(IWebDriver driver)
        {
            this.driver = driver;

            PageFactory.InitElements(driver, this);
        }

        public void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        
        [FindsBy(How = How.Id, Using = "userName")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "userEmail")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "currentAddress")]
        public IWebElement CA { get; set; }

        [FindsBy(How = How.Id, Using = "permanentAddress")]
        public IWebElement PA { get; set; }

        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement SubmitButton { get; set; }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }


    }
}
