using OpenQA.Selenium;
using SeleniumBase;

namespace The_Internet
{
    internal class BasicAuth : SelActions
    {
        public BasicAuth()
        {
            open("https://the-internet.herokuapp.com/basic_auth");

            wait2s();

            var al = switchToAlert();
            al.SendKeys("admin");
            al.SendKeys(Keys.Tab);
            al.SendKeys("admin");
            al.Accept();

            
        }
    }
}