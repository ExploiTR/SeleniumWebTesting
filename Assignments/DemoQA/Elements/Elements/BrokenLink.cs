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
using SeleniumBase;

namespace Elements
{
    internal class BrokenLink : SelActions
    {
        public void run(bool _continue)
        {
            try
            {
                open("https://demoqa.com/broken");

                ReadOnlyCollection<IWebElement> elements = FindAllBy(By.TagName("img"));

                IWebElement validImage = elements[2];
                IWebElement brokenImage = elements[3];

                Console.WriteLine("Valid Image Response : " + testForValidImage(getAttribute(validImage, "src")));
                Console.WriteLine("Broken Image Response : " + testForValidLink(getAttribute(brokenImage, "src")));

                wait(500);

                Console.WriteLine("Valid Link Response : " + testForValidLink(getAttribute(FindXPath("//a[text()='Click Here for Valid Link']"), "href")));
                Console.WriteLine("Broken Link Response : " + testForValidLink(getAttribute(FindXPath("//a[text()='Click Here for Broken Link']"), "href")));

                wait(3000);

                exit();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            if (_continue)
                new UploadAndDownload().run(_continue);
        }
    }
}
