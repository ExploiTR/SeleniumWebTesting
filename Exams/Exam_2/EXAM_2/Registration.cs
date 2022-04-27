using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EXAM_2
{
    internal class Registration
    {
        private static IWebDriver driver;
        public void start(bool chain)
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.way2automation.com/way2auto_jquery/registration.php#load_box");
            driver.Manage().Window.Maximize();

            sendName("Pratim");
            sendTitle("Majumder");
            sendMaritalStatus(0);
            sendHobbies();
            selectCountry("India");
            selectDate(1, 1, 2014);
            setPhone("+9103214911100");
            setUserName("tictactoe");
            setEmail("joe@gmail.com");
            setProfilePic();
            setAbout();
            setPassAndConfirmPass("demopass");
          //  submit();

            Console.ReadKey();
        }

        private void submit()
        {
            driver.FindElement(By.XPath("//input[@type='submit' and @value='submit']")).Click();
        }

        private void setProfilePic()
        {
            driver.FindElement(By.XPath("//fieldset//input[@type='file']")).SendKeys("C:\\Users\\" + Environment.UserName + "\\Desktop\\download.png");
        }

        private void setPassAndConfirmPass(string v)
        {
            IWebElement pass = driver.FindElement(By.XPath("//fieldset[@class='fieldset']//input[@name='password']"));
            pass.SendKeys(v);

            IWebElement c_pass = driver.FindElement(By.XPath("//fieldset[@class='fieldset']//input[@name='c_password']"));
            c_pass.SendKeys(v);
        }

        private void setAbout()
        {
            IWebElement element = driver.FindElement(By.XPath("//fieldset//textarea"));
            element.SendKeys("I'm a student not studying rn.");
        }

        private void setUserName(string v)
        {
            IWebElement element = driver.FindElement(By.XPath("//fieldset[@class='fieldset']//input[@name='username']"));
            element.SendKeys(v);
        }

        private void setEmail(string v)
        {
            IWebElement element = driver.FindElement(By.XPath("//fieldset[@class='fieldset']//input[@name='email']"));
            element.SendKeys(v);
        }

        private void setPhone(string v)
        {
            IWebElement element_ph = driver.FindElement(By.XPath("//fieldset[@class='fieldset']//input[@name='phone']"));
            element_ph.SendKeys(v);
        }

        private void selectDate(int d, int m, int y)
        {
            ReadOnlyCollection<IWebElement> date_fields = driver.FindElements(By.XPath("//div[@class='time_feild']//select"));

            date_fields[0].Click();
            Thread.Sleep(500);

            driver.SwitchTo().ActiveElement();

            Thread.Sleep(500);

            ReadOnlyCollection<IWebElement> date_fields_total = date_fields[0].FindElements(By.XPath("//option"));
            foreach (IWebElement element in date_fields_total)
            {
                if (element.Text.Equals(d + ""))
                {
                    element.Click();
                    break;
                }
            }

            date_fields[1].Click();
            Thread.Sleep(500);

            driver.SwitchTo().ActiveElement();

            Thread.Sleep(500);

            ReadOnlyCollection<IWebElement> month_fields_total = date_fields[1].FindElements(By.XPath("//option"));
            foreach (IWebElement element in month_fields_total)
            {
                if (element.Text.Trim().Equals(m + ""))
                {
                    Console.WriteLine("click");
                    element.Click();
                    break;
                }
            }

            date_fields[2].Click();
            Thread.Sleep(500);

            driver.SwitchTo().ActiveElement();

            Thread.Sleep(500);

            ReadOnlyCollection<IWebElement> year_fields_total = date_fields[0].FindElements(By.XPath("//option"));
            foreach (IWebElement element in year_fields_total)
            {
                if (element.Text.Equals(y + ""))
                {
                    element.Click();
                    break;
                }
            }

            driver.SwitchTo().ActiveElement().Click();
        }

        private void selectCountry(string v)
        {
            IWebElement countries = driver.FindElement(By.XPath("//fieldset//descendant::label[text()='Country:']//following-sibling::select[@name and @id]"));
            countries.Click();

            Thread.Sleep(1000);

            driver.SwitchTo().ActiveElement();

            ReadOnlyCollection<IWebElement> india_sel = driver.FindElements(By.XPath("//fieldset//descendant::label[text()='Country:']//following-sibling::select[@name and @id]//option"));
            foreach (IWebElement element in india_sel)
            {
                if (element.Text.Trim().Equals(v))
                {
                    element.Click();
                    break;
                }
            }

            driver.SwitchTo().ActiveElement().Click();
        }

        private void sendHobbies()
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//label[text()='Hobby:']//following::div[@class='radio_wrap']//descendant::input"));
            elements[1].Click();
            elements[2].Click();
        }

        private void sendName(string name)
        {
            IWebElement f_name = driver.FindElement(By.XPath("//fieldset[@class='fieldset']//descendant::input[@name='name']"));
            f_name.SendKeys(name);
        }

        private void sendTitle(string title)
        {
            IWebElement l_name = driver.FindElements(By.XPath("//fieldset[@class='fieldset']//descendant::input[@name='name']//following::input[@type='text']"))[0];
            l_name.SendKeys(title);
        }

        private void sendMaritalStatus(int v)
        {
            driver.FindElements(By.XPath("//input[@name='m_status']"))[v].Click();
        }

    }
}
