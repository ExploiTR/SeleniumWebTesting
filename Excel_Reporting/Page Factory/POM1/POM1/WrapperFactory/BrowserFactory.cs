using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace POM1.WrapperFactory
{
    class BrowserFactory
    {

        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();

        protected static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was NOT initialized, You need to call the method initBrowser");
                }

                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void initBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (Driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }
                    break;

                case "IE":
                    if (Driver == null)
                    {
                        driver = new InternetExplorerDriver();
                        Drivers.Add("IE", Driver);
                    }
                    break;

                default:
                    driver = new ChromeDriver();
                    Drivers.Add("Chrome", Driver);
                    break;
            }
        }

        public static void loadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDriver()
        {
            foreach(var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}
