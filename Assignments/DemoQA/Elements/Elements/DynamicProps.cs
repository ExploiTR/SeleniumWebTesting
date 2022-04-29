using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using SeleniumBase;

namespace Elements
{
    internal class DynamicProps : SelActions
    {
        public void run()
        {
            open("https://demoqa.com/dynamic-properties");

            IWebElement enableAfter5 = FindID("enableAfter");
            IWebElement coloredButton = FindID("colorChange");
            ReadOnlyCollection<IWebElement> visibleAfter5 = FindAllBy(By.Id("visibleAfter"));

            string initialButtonColor = coloredButton.GetCssValue("color");

            Assert.IsFalse(enableAfter5.Enabled);
            Assert.IsTrue(visibleAfter5.Count == 0);

            wait(5100);

            ReadOnlyCollection<IWebElement> visibleAfter5_ = FindAllBy(By.Id("visibleAfter"));

            Assert.IsTrue(enableAfter5.Enabled);
            Assert.IsTrue(visibleAfter5_.Count > 0);
            Assert.AreNotEqual(initialButtonColor, coloredButton.GetCssValue("color"));

            wait(3000);

            exit();

        }
    }
}
