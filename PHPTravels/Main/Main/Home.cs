using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main
{
    internal class Home
    {
        public void start(bool continue_)
        {

            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://www.phptravels.net/");
                driver.Manage().Window.Maximize();

                IWebElement element = driver.FindElement(By.XPath("//span[@id='select2-hotels_city-container']"));
                element.Click();

                Thread.Sleep(250);

                IWebElement searchInput = driver.FindElement(By.XPath("//input[@class='select2-search__field']"));
                searchInput.SendKeys("India");

                IWebElement locationList = driver.FindElement(By.XPath("//ul[starts-with(@class,'select2-results__option')]"));

                while (!locationList.Displayed)
                {
                    //wait
                }

                Thread.Sleep(5000);

                ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//li[starts-with(@class,'select2-results__option')]"));

                elements[new Random().Next(0, elements.Count)].Click();

                Thread.Sleep(1000);


                IWebElement fromDate = driver.FindElement(By.XPath("//input[@id='checkin']"));
                fromDate.Click();

                Thread.Sleep(2000);

                driver.SwitchTo().ActiveElement();

                IWebElement fromContainer = driver.FindElement(By.XPath("//div[contains(@class,'dropdown-menu') and contains(@style,'block')]"));
                IWebElement nextMon = fromContainer.FindElement(By.XPath("//th[@class='next']"));

                nextMon.Click();

                //ReadOnlyCollection <IWebElement> dateRow = fromContainer.FindElements(By.XPath("//div[@class='datepicker-days' and contains(@style,'block')]//tbody/tr"));

                //div[contains(@class,'dropdown-menu') and contains(@style,'block')]
                //div[@class='datepicker-days' and contains(@style,'block')]
                //td[@class='day ' and text()=25]

                //table[@class = ' table-condensed']//th[@class='switch'] - for reading current month and setting according to it

                Thread.Sleep(1000);

                IWebElement element25th = fromContainer.FindElement(By.XPath("//td[@class='day ' and text()=25]"));
                element25th.Click();

                IWebElement toDate = driver.FindElement(By.XPath("//input[@id='checkout']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", toDate);

                Thread.Sleep(1000);

                IWebElement toContainer = driver.FindElement(By.XPath("//div[contains(@class,'dropdown-menu') and contains(@style,'block')]"));
                //  driver.SwitchTo().Frame(toContainer);

                new Actions(driver).MoveToElement(toContainer).Perform();

                Console.WriteLine(toContainer.GetAttribute("innerHTML"));

                Thread.Sleep(1000);

            /*    IWebElement nextMon2 = toContainer.FindElement(By.XPath("//th[@class='next']"));

                Thread.Sleep(1000);

                nextMon2.Click();

                Thread.Sleep(1000);

                IWebElement element24th = toContainer.FindElement(By.XPath("//td[@class='day ' and text()=27]"));
                element24th.Click();*/

                driver.FindElement(By.XPath("//a[contains(@class,'travellers') and contains(@class,'dropdown-toggle')]")).Click();

                Thread.Sleep(1000);

                driver.SwitchTo().ActiveElement();

                driver.FindElement(By.XPath("//div[@class='roomInc']")).Click();

                Thread.Sleep(1000);

                driver.FindElement(By.XPath("//div[@class='roomDec']"));

                IWebElement natSearch = driver.FindElement(By.XPath("//select[@class='form-select nationality']"));
                natSearch.Click();
                Thread.Sleep(500);
                driver.SwitchTo().ActiveElement();
                Thread.Sleep(500);
                natSearch.SendKeys("India");
                Thread.Sleep(500);
                // new Actions(driver).SendKeys(Keys.Enter);
                natSearch.SendKeys(Keys.Enter);

                Thread.Sleep(1000);

                driver.FindElement(By.XPath("//div[contains(@class,'btn-search')]")).Click();    

                Thread.Sleep(5000);
                driver.Quit();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                driver.Quit();
                Thread.CurrentThread.Interrupt();
            }
        }
    }
}
