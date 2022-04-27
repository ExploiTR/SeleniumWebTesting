using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Elements
{
    internal class BrokenLink
    {
        public void run(bool _continue)
        {
            IWebDriver driver = new ChromeDriver();
            var executor = (IJavaScriptExecutor)driver;

            try
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://demoqa.com/broken");

                ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.TagName("img"));

                IWebElement validImage = elements[2]; 
                IWebElement brokenImage = elements[3];

                Assert.IsTrue(isImageOkay(validImage.GetAttribute("src")));

                Thread.Sleep(2000);

                Assert.IsFalse(isImageOkay(brokenImage.GetAttribute("src")));

                Thread.Sleep(500);

                IWebElement validLink = driver.FindElement(By.XPath("//a[text()='Click Here for Valid Link']"));
                string linkValid = validLink.GetAttribute("href");

                IWebElement brokenLink = driver.FindElement(By.XPath("//a[text()='Click Here for Broken Link']"));
                string linkBroken = brokenLink.GetAttribute("href");

                Thread.Sleep(500);

                Assert.IsTrue(isLinkOkay(linkValid));
                Assert.IsFalse(isLinkOkay(linkBroken));

                Console.WriteLine("Checks Successful!");

                Thread.Sleep(3000);

                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(5000);
                driver.Quit();
            }

            if (_continue)
                new UploadAndDownload().run(_continue);
        }

        private bool isLinkOkay(string link)
        {
            //problem : broken link has 200 response and content-length
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(link);
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                Console.WriteLine(link + " >> " + response.ContentLength);

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool isImageOkay(string link)
        {
            //problem : broken image has 200 response and content-length
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(link);
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                Console.WriteLine(link + " >> " + response.ContentLength);

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
