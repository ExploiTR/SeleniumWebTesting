using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.freecodecamp.org/news/how-to-use-html-to-open-link-in-new-tab/");

            Thread.Sleep(500);

            foreach(IWebElement elements in driver.FindElements(By.XPath("//*[@target='_blank']"))) { 
            
                elements.Click();
                break;
            }

            Thread.Sleep(250);

         //   String curWin = driver.CurrentWindowHandle;

            driver.Close();

            Thread.Sleep(500);

        //    driver.SwitchTo().Window(curWin);

        //   Console.WriteLine(driver.CurrentWindowHandle); // no such window : target window already closed
        //    Console.WriteLine(driver.Title); // failed to read descriptor

          //  Console.ReadKey();

            Thread.Sleep(2000);

            driver.Quit();
        }
    }
}
