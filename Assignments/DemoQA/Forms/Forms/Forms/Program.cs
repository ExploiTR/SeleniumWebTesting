using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using SeleniumBase;

namespace Forms
{
    internal class Program : SelActions
    {
        static void Main(string[] args)
        {
            new Program().run();
        }

        private void run()
        {
            open("https://demoqa.com/automation-practice-form");

            setName("Pratim");
            setLastName("Majumder");
            setEmail("example@india.com");
            setGender();
            setPhone("1234567890");

            checkDate();
            setSubject("English");
            setHobbies();

            uploadPic();
            setAddress("The Earth");

            setState("NCR");
            setCity("Delhi");

            submitForm();

            wait(2000);
            closeModal();

            wait(1000);
            exit();
        }

        private void closeModal()
        {
            wait(1000);
            switchToActive();
            click(FindXPath("//button[@id='closeLargeModal']"));
        }

        private void submitForm()
        {
            click(FindXPath("//button[@id='submit']"));
        }

        private void setCity(string v)
        {
            click(FindXPath("//div[@id='city']"));
            var x = FindXPath("//input[@id='react-select-4-input']");
            x.SendKeys(v);
            x.SendKeys(Keys.Enter);
        }

        private void setState(string v)
        {
            click(FindXPath("//div[@id='state']"));
            var x = FindXPath("//input[@id='react-select-3-input']");
            x.SendKeys(v);
            x.SendKeys(Keys.Enter);
        }

        private void setAddress(string v)
        {
            sendKeys(FindXPath("//textarea[@id='currentAddress']"), v);
        }

        private void uploadPic()
        {
            sendKeys(FindXPath("//input[@id='uploadPicture']"), "C:\\Users\\ExploiTR\\Desktop\\download.png");
        }

        private void setHobbies()
        {
            click(FindXPath("//label[@for='hobbies-checkbox-2']"));
        }

        private void setSubject(string v)
        {
            var x = FindXPath("//input[@id='subjectsInput']");
            x.SendKeys(v);
            x.SendKeys(Keys.Enter);
        }

        private void checkDate()
        {
            click(FindXPath("//input[@id='dateOfBirthInput']"));

            wait(500);

            checkDateManual("25 Jun 2030");

            wait(1000);

            checkDateInternal();
        }

        private void checkDateInternal()
        {
            switchToActive();

            IWebElement next_mon_arrow = FindXPath("//button[text()='Next Month']");
            IWebElement prev_mon_arrow = FindXPath("//button[text()='Previous Month']");

            prev_mon_arrow.Click();
            Thread.Sleep(500);
            next_mon_arrow.Click();
            Thread.Sleep(500);

            IWebElement mon_sel = FindXPath("//select[@class='react-datepicker__month-select']");
            IWebElement year_sel = FindXPath("//select[@class='react-datepicker__year-select']");

            mon_sel.Click();
            click(FindWithInElement(By.XPath("//option[@value='5']"), mon_sel));

            year_sel.Click();
            click(FindWithInElement(By.XPath("//option[@value='2022']"), year_sel));

            click(FindXPath("//div[text()='22']"));

            switchToDefault();
        }

        /*
         *  BUG : Clearing date makes website invisible.
         */
        private void checkDateManual(string v)
        {
            return;

#pragma warning disable CS0162

            IWebElement x = FindXPath("//input[@id='dateOfBirthInput']");
            Actions action = new Actions(getDriver());
            action.KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .KeyDown(Keys.Delete)
                .KeyUp(Keys.Delete)
                .Build().Perform();
            x.SendKeys(v);
        }

        private void setPhone(string v)
        {
            sendKeys(FindXPath("//input[@id='userNumber']"), v);
        }

        private void setGender()
        {
            click(FindXPath("//label[@for='gender-radio-1']"));
        }

        private void setEmail(string v)
        {
            sendKeys(FindXPath("//input[@id='userEmail']"), v);
        }

        private void setLastName(string v)
        {
            sendKeys(FindXPath("//input[@id='lastName']"), v);
        }

        private void setName(string v)
        {
            sendKeys(FindXPath("//input[@id='firstName']"), v);
        }


    }
}
