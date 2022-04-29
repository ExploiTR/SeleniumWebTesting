using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BookStore
{
    internal class BookStore : SelActions
    {
        public void explore(IWebDriver webDriver)
        {
            setDriver(webDriver);

            getDriver().Navigate().GoToUrl("https://demoqa.com/books");

            searchBook("git");
            addFirstBookToCollection();
            searchBook("script");
            addFirstBookToCollection();
            loadProfile();
            deleteBooks();
            logout();
        }

        private void logout()
        {
            FindXPath("//div[contains(@class,'text-right')]//button[text()='Log out']").Click();
            wait(2000);
        }

        private void deleteBooks()
        {
            FindXPath("//div[contains(@class,'text-right')]//button[text()='Delete All Books']").Click();
            wait(1000);
            switchToActive();
            wait(1000);
            FindID("closeSmallModal-ok").Click();
            wait(1000);
            acceptAlert();
            wait(1000);
        }

        private void loadProfile()
        {
            getDriver().Navigate().GoToUrl("https://demoqa.com/profile");
            wait(2000);
        }

        private void addFirstBookToCollection()
        {
            var books = FindAllBy(By.XPath("//div[@class='rt-tr-group']//span//a"));
            books[0].Click();
            wait(1000);
            FindXPath("//button[text()='Add To Your Collection']").Click();
            wait(1000);
            acceptAlert();
            switchToDefault();
            wait(1000);
            FindXPath("//button[text()='Back To Book Store']").Click();
            wait(1000);
        }

        private void searchBook(string v)
        {
            FindXPath("//input[@id='searchBox']").SendKeys(v);
            wait(1000);
        }
    }
}
