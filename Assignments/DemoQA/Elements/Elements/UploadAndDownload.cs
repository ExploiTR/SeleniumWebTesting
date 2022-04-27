using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Elements
{
    internal class UploadAndDownload
    {
        public void run(bool _continue)
        {
            ChromeOptions options = new ChromeOptions();

            options.AddUserProfilePreference("download.default_directory", "C:\\Users\\"+ Environment.UserName + "\\Desktop");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);

            IWebDriver driver = new ChromeDriver(options);

            try
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/upload-download");

                driver.FindElement(By.Id("downloadButton")).Click();

                Thread.Sleep(5000);

                driver.FindElement(By.Id("uploadFile")).SendKeys("C:\\Users\\" + Environment.UserName + "\\Desktop\\Removed Apps.html");

                Console.WriteLine("Checks Successful!");

                Thread.Sleep(5000);

                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(5000);
                driver.Quit();
            }

            if (_continue)
            {
                new DynamicProps().run();
            }
        }
    }
}
