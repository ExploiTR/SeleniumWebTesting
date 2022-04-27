using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Design;

namespace Samples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/");

            var links = driver.FindElements(By.XPath("//a[@href]"));
            Console.WriteLine("Total Links  : " + links.Count);
            foreach (var item in links)
            {
                Console.WriteLine(item.GetAttribute("href"));
            }
            Console.WriteLine();
            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
            sc.SaveAsFile("C:\\Users\\ExploiTR\\Desktop\\test.png");

            driver.Navigate().Refresh();

            Console.ReadKey();
        }
    }
}
