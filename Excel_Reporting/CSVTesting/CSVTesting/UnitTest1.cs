using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ExcelDataTesting
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        IJavaScriptExecutor jsEx;

        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void CSVData()
        {
            driver = new ChromeDriver();
            jsEx = (IJavaScriptExecutor)driver;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            driver.FindElement(By.Id("userName")).SendKeys(TestContext.DataRow[0].ToString());
            driver.FindElement(By.Id("userEmail")).SendKeys(TestContext.DataRow[1].ToString());
            driver.FindElement(By.Id("currentAddress")).SendKeys(TestContext.DataRow[2].ToString());
            driver.FindElement(By.Id("permanentAddress")).SendKeys(TestContext.DataRow[3].ToString());

            jsEx.ExecuteScript("window.scrollBy(0,250)");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("submit")).Click();
            driver.Close();
            driver.Quit();
        }
    }
}
