using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ExcelDataTesting
{
    // 1. Put XML File under the project solution
    // 2. Click on Show All Files
    // 3. Right Click on XML File -> Include
    // 4. Again Right Click on XML File -> Properties
    // Change "Do Not Copy" to "Copy Always"

    [TestClass]
    public class UnitTest1
    {
        IWebDriver Driver;
        IJavaScriptExecutor Js;

        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\XMLData.xml", "user", DataAccessMethod.Sequential)]
        [TestMethod]
        public void ExcelData()
        {
            Driver = new ChromeDriver();
            Js = (IJavaScriptExecutor)Driver;
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            Driver.FindElement(By.Id("userName")).SendKeys(TestContext.DataRow[0].ToString());
            Driver.FindElement(By.Id("userEmail")).SendKeys(TestContext.DataRow[1].ToString());
            Driver.FindElement(By.Id("currentAddress")).SendKeys(TestContext.DataRow[2].ToString());
            Driver.FindElement(By.Id("permanentAddress")).SendKeys(TestContext.DataRow[3].ToString());

            Js.ExecuteScript("window.scrollBy(0,250)");

            Thread.Sleep(2000);
            Driver.FindElement(By.Id("submit")).Click();
            Driver.Close();
            Driver.Quit();
        }
    }
}
