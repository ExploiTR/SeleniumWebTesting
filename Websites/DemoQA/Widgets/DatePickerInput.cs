using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Widgets
{
    internal class DatePickerInput
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://demoqa.com/date-picker");

            activateDateCalender();

            checkManualTextDateInput();
            checkPrevMonthArrow();
            checkNextMonthArrow();
            checkMonthDropDown();
            checkYearDropDown();
            checkDateSelect();

            activateDateTimeCalender();
            checkTimeManual();
            checkTimeAuto();

            driver.Quit();

            if (chain)
            {
                new Slider().start(chain);
            }
        }

        private void checkTimeAuto()
        {
            IWebElement x = driver.FindElement(By.XPath("//input[@id='dateAndTimePickerInput']"));
            x.Click();
            Thread.Sleep(500);
            driver.SwitchTo().ActiveElement();
            driver.FindElement(By.XPath("//li[text()='22:45']")).Click();
            Thread.Sleep(1000);
        }

        private void checkTimeManual()
        {
            IWebElement x = driver.FindElement(By.XPath("//input[@id='dateAndTimePickerInput']"));
            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .KeyDown(Keys.Delete)
                .KeyUp(Keys.Delete)
                .Build().Perform();
            x.SendKeys("April 24, 2025 06:22 PM");
        }

        private void activateDateTimeCalender()
        {
            driver.FindElement(By.Id("dateAndTimePickerInput")).Click();
            Thread.Sleep(500);
            driver.SwitchTo().ActiveElement();
        }

        private void checkDateSelect()
        {
            driver.FindElement(By.XPath("//div[text()='22']")).Click();
            driver.SwitchTo().DefaultContent();
        }

        private void checkYearDropDown()
        {
            IWebElement year_sel = driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
            year_sel.Click();
            year_sel.FindElement(By.XPath("//option[@value='2022']")).Click();
        }

        private void checkMonthDropDown()
        {
            IWebElement mon_sel = driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            mon_sel.Click();
            mon_sel.FindElement(By.XPath("//option[@value='5']")).Click();
        }

        private void checkNextMonthArrow()
        {
            IWebElement next_mon_arrow = driver.FindElement(By.XPath("//button[text()='Next Month']"));
            next_mon_arrow.Click();
            Thread.Sleep(500);
        }

        private void checkPrevMonthArrow()
        {
            IWebElement prev_mon_arrow = driver.FindElement(By.XPath("//button[text()='Previous Month']"));
            prev_mon_arrow.Click();
            Thread.Sleep(500);
        }

        private void checkManualTextDateInput()
        {
            IWebElement x = driver.FindElement(By.XPath("//input[@id='datePickerMonthYearInput']"));
            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .KeyDown(Keys.Delete)
                .KeyUp(Keys.Delete)
                .Build().Perform();
            x.SendKeys("05/26/2023");
        }

        private void activateDateCalender()
        {
            driver.FindElement(By.Id("datePickerMonthYearInput")).Click();
            Thread.Sleep(500);
            driver.SwitchTo().ActiveElement();
        }
    }
}
