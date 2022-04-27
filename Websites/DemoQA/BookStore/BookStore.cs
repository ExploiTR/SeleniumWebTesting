using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BookStore
{
    internal class BookStore
    {
        private static IWebDriver driver;
        public void explore(IWebDriver _driver)
        {
            driver = _driver;

            driver.Navigate().GoToUrl("https://demoqa.com/books");

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
            driver.FindElement(By.XPath("//div[contains(@class,'text-right')]//button[text()='Log out']")).Click();
            Thread.Sleep(2000);
        }

        private void deleteBooks()
        {
            driver.FindElement(By.XPath("//div[contains(@class,'text-right')]//button[text()='Delete All Books']")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().ActiveElement();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("closeSmallModal-ok")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
        }

        private void loadProfile()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/profile");
            Thread.Sleep(2000);
        }

        private void addFirstBookToCollection()
        {
            var books = driver.FindElements(By.XPath("//div[@class='rt-tr-group']//span//a"));
            books[0].Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[text()='Add To Your Collection']")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[text()='Back To Book Store']")).Click();
            Thread.Sleep(1000);
        }

        private void searchBook(string v)
        {
            driver.FindElement(By.XPath("//input[@id='searchBox']")).SendKeys(v);
            Thread.Sleep(1000);
        }
    }
}
