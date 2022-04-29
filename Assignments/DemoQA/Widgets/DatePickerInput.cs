using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumBase;

namespace Widgets
{
    internal class DatePickerInput : SelActions
    {
        public void start(bool chain)
        {
            open("https://demoqa.com/date-picker");

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

            exit();

            if (chain)
            {
                new Slider().start(chain);
            }
        }

        private void checkTimeAuto()
        {
            FindXPath("//input[@id='dateAndTimePickerInput']").Click();
            wait(500);
            switchToActive();
            FindXPath("//li[text()='22:45']").Click();
            wait(1000);
        }

        private void checkTimeManual()
        {
            IWebElement x = FindXPath("//input[@id='dateAndTimePickerInput']");
            getAction().KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .KeyDown(Keys.Delete)
                .KeyUp(Keys.Delete)
                .Build().Perform();
            x.SendKeys("April 24, 2025 06:22 PM");
        }

        private void activateDateTimeCalender()
        {
            FindID("dateAndTimePickerInput").Click();
            wait(500);
            switchToActive();
        }

        private void checkDateSelect()
        {
            FindXPath("//div[text()='22']").Click();
            switchToDefault();
        }

        private void checkYearDropDown()
        {
            IWebElement year_sel = FindXPath("//select[@class='react-datepicker__year-select']");
            year_sel.Click();
            FindWithInElement(By.XPath("//option[@value='2022']"), year_sel).Click();
        }

        private void checkMonthDropDown()
        {
            IWebElement mon_sel = FindXPath("//select[@class='react-datepicker__month-select']");
            mon_sel.Click();
            mon_sel.FindElement(By.XPath("//option[@value='5']")).Click();
        }

        private void checkNextMonthArrow()
        {
            FindXPath("//button[text()='Next Month']").Click();
            wait(500);
        }

        private void checkPrevMonthArrow()
        {
            FindXPath("//button[text()='Previous Month']").Click();
            wait(500);
        }

        private void checkManualTextDateInput()
        {
            IWebElement x = FindXPath("//input[@id='datePickerMonthYearInput']");
            getAction().KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .KeyDown(Keys.Delete)
                .KeyUp(Keys.Delete)
                .Build().Perform();
            x.SendKeys("05/26/2023");
        }

        private void activateDateCalender()
        {
            FindID("datePickerMonthYearInput").Click();
            wait(500);
            switchToActive();
        }
    }
}
