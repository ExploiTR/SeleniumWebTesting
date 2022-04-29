using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBase;
using System;
using System.Threading;
using SeleniumBase;

namespace Elements
{
    internal class UploadAndDownload : SelActions
    {
        public void run(bool _continue)
        {
            ChromeOptions options = new ChromeOptions();

            options.AddUserProfilePreference("download.default_directory", "C:\\Users\\" + Environment.UserName + "\\Desktop");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("safebrowsing.enabled", true);

            DriverConfig config = new DriverConfig();
            config.Maximize = true;
            config.ChromeOptions = options;

            open("https://demoqa.com/upload-download",config);

            click(FindID("downloadButton"));

            wait(5000);

            sendKeys(FindID("uploadFile"), "C:\\Users\\" + Environment.UserName + "\\Desktop\\Removed Apps.html");

            Thread.Sleep(5000);

            exit();

            if (_continue)
            {
                new DynamicProps().run();
            }
        }
    }
}
