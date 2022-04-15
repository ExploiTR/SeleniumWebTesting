using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Fast.com
{
    internal class Program
    {
        static long timeCount;
        static string format;
        static FileStream stream;

        static void Main(string[] args)
        {
            long timeIn = DateTime.Now.Millisecond;
            if (args.Count() != 0)
            {
                timeCount = long.Parse(args[0].Trim());
                format = args[1].Trim();

                switch (format)
                {
                    case "h":
                        {
                            timeIn = timeIn + (timeCount * 3600);
                            break;
                        }
                    case "m":
                        {
                            timeIn = timeIn + (timeCount * 60);
                            break;
                        }
                    default:
                        {
                            timeIn = timeIn + timeCount;
                            break;
                        }
                }
            }
            else {
                timeCount = 24;
                format = "h";
                timeIn += DateTime.Now.Millisecond + (24 * 3600);
            }

            Console.WriteLine("ETA : " + timeCount + format + " ( " + DateTime.Now.Millisecond + " / " + timeIn + " )");

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://fast.com/");

            IWebElement element = driver.FindElement(By.Id("show-more-details-link"));

            while (!element.Displayed)
            {
                //wait
                Thread.Sleep(500);
            }

            element.Click();
            Thread.Sleep(2500); //wait for start upload

            createFile();

            for (; ; )
            {
                if (timeIn < DateTime.Now.Millisecond)
                {
                    break;
                }
                IWebElement reload = reloadButton(driver);
                if (reload != null && reload.Displayed)
                {
                    writeFile(driver);
                    reload.Click();
                    Thread.Sleep(5000);
                }
            }

            stream.Close();
            driver.Quit();
        }

        private static void createFile()
        {
            if (stream == null) { 
                stream = new FileStream("C:\\Users\\ExploiTR\\Desktop\\Record.txt", FileMode.Append, FileAccess.Write);
            }
        }

        private static void writeFile(IWebDriver driver)
        {
            string dlVal = downloadSpeed(driver);
            string ulVal = uploadSpeed(driver);

            if (!stream.CanWrite)
            {
                Console.WriteLine("Fatal Error : Can't update record!");
                Thread.Sleep(5000);
                driver.Quit();
            }
            else {
                StreamWriter sw = new StreamWriter(stream);
                sw.WriteLine(dlVal + " , " + ulVal + " ," + " " + DateTime.Now.ToString());
                sw.Flush();
                sw.Close();
            }
        }

        private static IWebElement reloadButton(IWebDriver driver)
        {
            try
            {
                return driver.FindElement(By.XPath("//span[contains(@class,'oc-icon-refresh')]"));
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string downloadSpeed(IWebDriver driver)
        {
            try
            {
                return driver.FindElement(By.Id("speed-value")).Text;
            }
            catch (Exception) {
                return "FAIL";
            }
        }

        private static string uploadSpeed(IWebDriver driver)
        {
            try
            {
                return driver.FindElement(By.Id("upload-value")).Text;
            }
            catch (Exception)
            {
                return "FAIL";
            }
        }
    }
}
