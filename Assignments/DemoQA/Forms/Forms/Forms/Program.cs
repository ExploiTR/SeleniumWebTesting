using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace Forms
{
    internal class Program
    {
        private static IWebDriver driver;
        static void Main(string[] args)
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

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
            closeModal();

            Console.ReadKey();
        }

        private static void closeModal()
        {
            Thread.Sleep(1000);
            driver.SwitchTo().ActiveElement();

            driver.FindElement(By.XPath("//button[@id='closeLargeModal']")).Click();
        }

        private static void submitForm()
        {
            driver.FindElement(By.XPath("//button[@id='submit']")).Click();
        }

        private static void setCity(string v)
        {
            driver.FindElement(By.XPath("//div[@id='city']")).Click();
            var x = driver.FindElement(By.XPath("//input[@id='react-select-4-input']"));
            x.SendKeys(v);
            x.SendKeys(Keys.Enter);
        }

        private static void setState(string v)
        {
            driver.FindElement(By.XPath("//div[@id='state']")).Click();
            var x = driver.FindElement(By.XPath("//input[@id='react-select-3-input']"));
            x.SendKeys(v);
            x.SendKeys(Keys.Enter);
        }

        private static void setAddress(string v)
        {
            driver.FindElement(By.XPath("//textarea[@id='currentAddress']")).SendKeys(v);
        }

        private static void uploadPic()
        {
            driver.FindElement(By.XPath("//input[@id='uploadPicture']")).SendKeys("C:\\Users\\ExploiTR\\Desktop\\download.png");
        }

        private static void setHobbies()
        {
            driver.FindElement(By.XPath("//label[@for='hobbies-checkbox-2']")).Click();
        }

        private static void setSubject(string v)
        {
            var x = driver.FindElement(By.XPath("//input[@id='subjectsInput']"));
            x.SendKeys(v);
            x.SendKeys(Keys.Enter);
        }

        private static void checkDate()
        {
            driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']")).Click();

            Thread.Sleep(500);

            checkDateManual("25 Jun 2030");

            Thread.Sleep(1000);

            checkDateInternal();
        }

        private static void checkDateInternal()
        {
            driver.SwitchTo().ActiveElement();

            IWebElement next_mon_arrow = driver.FindElement(By.XPath("//button[text()='Next Month']"));
            IWebElement prev_mon_arrow = driver.FindElement(By.XPath("//button[text()='Previous Month']"));

            prev_mon_arrow.Click();
            Thread.Sleep(500);
            next_mon_arrow.Click();
            Thread.Sleep(500);

            IWebElement mon_sel = driver.FindElement(By.XPath("//select[@class='react-datepicker__month-select']"));
            IWebElement year_sel = driver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));

            mon_sel.Click();
            mon_sel.FindElement(By.XPath("//option[@value='5']")).Click();

            year_sel.Click();
            year_sel.FindElement(By.XPath("//option[@value='2022']")).Click();

            driver.FindElement(By.XPath("//div[text()='22']")).Click();

            driver.SwitchTo().DefaultContent();
        }

        /*
         *  BUG : Clearing date makes website invisible.
         */
        private static void checkDateManual(string v)
        {
            return;

#pragma warning disable CS0162

            IWebElement x = driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']"));
            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .KeyDown(Keys.Delete)
                .KeyUp(Keys.Delete)
                .Build().Perform();
            x.SendKeys(v);
        }

        private static void setPhone(string v)
        {
            driver.FindElement(By.XPath("//input[@id='userNumber']")).SendKeys(v);
        }

        private static void setGender()
        {
            driver.FindElement(By.XPath("//label[@for='gender-radio-1']")).Click();
        }

        private static void setEmail(string v)
        {
            driver.FindElement(By.XPath("//input[@id='userEmail']")).SendKeys(v);
        }

        private static void setLastName(string v)
        {
            driver.FindElement(By.XPath("//input[@id='lastName']")).SendKeys(v);
        }

        private static void setName(string v)
        {
            driver.FindElement(By.XPath("//input[@id='firstName']")).SendKeys(v);
        }


    }
}
