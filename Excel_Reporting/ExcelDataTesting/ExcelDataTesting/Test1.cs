using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ExcelDataTesting
{
    // 1. Put Excel File under the project solution
    // 2. Click on Show All Files
    // 3. Right Click on Excel File -> Include
    // 4. Again Right Click on Excel File -> Properties
    // Change "Do Not Copy" to "Copy Always"

    [TestClass]
    public class Test1
    {
        IWebDriver Driver;
        IJavaScriptExecutor Js;

        public static IEnumerable<object[]> ReadExcel()
        {
            using (ExcelPackage EPackage = new ExcelPackage(new FileInfo("TestData.xlsx")))
            {
                ExcelWorksheet EWS = EPackage.Workbook.Worksheets["TestData"];

                int RowCount = EWS.Dimension.End.Row;

                for (int row = 2; row <= RowCount; row++)
                {
                    yield return new object[]
                    {
                        EWS.Cells[row, 1].Value?.ToString().Trim(),
                        EWS.Cells[row, 2].Value?.ToString().Trim(),
                        EWS.Cells[row, 3].Value?.ToString().Trim(),
                        EWS.Cells[row, 4].Value?.ToString().Trim(),
                    };
                }
            }
        }

        [DynamicData(nameof(ReadExcel), DynamicDataSourceType.Method)]
        [TestMethod]
        public void ExcelData(string name, string email, string ca, string pa)
        {
            Driver = new ChromeDriver();
            Js = (IJavaScriptExecutor)Driver;
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            Driver.FindElement(By.Id("userName")).SendKeys(name);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("currentAddress")).SendKeys(ca);
            Driver.FindElement(By.Id("permanentAddress")).SendKeys(pa);

            Js.ExecuteScript("window.scrollBy(0,250)");

            Thread.Sleep(2000);
            Driver.FindElement(By.Id("submit")).Click();
            Driver.Close();
            Driver.Quit();
        }
    }
}
